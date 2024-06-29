using Extensions;
using Level.AnalyticsNM;
using Level.CameraNM;
using Level.CameraNM.Clamping.Data;
using Level.CharacterNM;
using Level.CharacterNM.CharacterMovement.CharacterInputNM;
using Level.CharacterNM.CharacterStateMachineNM;
using Level.CharacterNM.CharacterStateMachineNM.StateTransitions;
using Level.Gravitation;
using Level.Gravitation.SwipeHandlerNM;
using Level.LevelStarNM;
using Level.Restart;
using Level.UserInterface;
using Level.UserInterface.Panels.GameplayPanel;
using Level.UserInterface.Panels.GameplayPanel.MovementButtons;
using Level.UserInterface.Panels.WinPanel;
using MonoBehaviourWrapperNM;
using SaveSystem;
using UnityEngine;

namespace Level.CompositionRoot
{
    public class EntryPoint : MonoBehaviourWrapper
    {
        [SerializeField] private TransitionsConditionsFactory _conditionsFactory;
        [SerializeField] private StarPickupFeedback _starPickupFeedback;
        [SerializeField] private SwipeHandler _swipeHandler;
        [SerializeField] private InputButton _rightButton;
        [SerializeField] private InputButton _leftButton;
        [SerializeField] private LevelStar[] _levelStars;
        [SerializeField] private CameraData _cameraData;
        [SerializeField] private MainCamera _mainCamera;
        [SerializeField] private LevelBorders _borders;
        [SerializeField] private Character _character;
        [SerializeField] private UI _ui;

        private void Awake()
        {
            LevelItems levelItems = new();
            Reward reward = new(_levelStars);
            PollingEvent restartEvent = new();
            CharacterGravityState gravityState = new(_swipeHandler);
            CharacterInput input = new InputProvider(_leftButton, _rightButton, gravityState).GetInput();
            TransitionsConditions conditions = _conditionsFactory.Create(_character, _borders, input, restartEvent);
            DeathAnalytics deathAnalytics = new(3, conditions.Death);
            
            _levelStars.ForEach(levelStar => levelStar.Initialize(_starPickupFeedback, gravityState));
            _character.Initialize(conditions, gravityState, input, _swipeHandler);
            _cameraData.Initialize(_borders, gravityState, _character);
            _mainCamera.Initialize(_cameraData);
            levelItems.InitializeGravityBoxes(_swipeHandler);
            levelItems.InitializeTurrets(gravityState);
            levelItems.InitializeGravityButtons();
            _ui.Find<WinPanel>().Initialize(reward);
            
            SetDependencies(new IUnityCallback[]
            {
                new LevelRestart(restartEvent.Invoke, _character.States.DieState),
                new UIHandler(_character.States, _character, _ui),
                new UIGravityBoxCover(levelItems.GravityBoxes, _ui.Find<GameplayPanel>()),
                new LevelResultSave(_character.States.WinState, reward),
                new Analytics(_character.States.WinState, _character.States.DieState, reward, deathAnalytics),
                reward,
            });
        }
    }
}