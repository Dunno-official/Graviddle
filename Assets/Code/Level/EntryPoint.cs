using Extensions;
using Level.CameraNM;
using Level.CameraNM.Clamping.Data;
using Level.CharacterNM;
using Level.CharacterNM.CharacterMovement.CharacterInputNM;
using Level.CharacterNM.CharacterStateMachine.StateTransitions;
using Level.Gravitation;
using Level.Gravitation.SwipeHandlerNM;
using Level.GravityBoxNM;
using Level.LevelStarNM;
using Level.Obstacles;
using Level.Restart;
using Level.UserInterface;
using Level.UserInterface.Panels.GameplayPanel;
using Level.UserInterface.Panels.GameplayPanel.MovementButtons;
using MonoBehaviourWrapperNM;
using SaveSystem;
using UnityEngine;

namespace Level
{
    public class EntryPoint : MonoBehaviourWrapper
    {
        [SerializeField] private TransitionsConditions _transitionsConditions;
        [SerializeField] private LevelStarsMediator _levelStarsMediator;
        [SerializeField] private LevelResultSave _levelResultSave;
        [SerializeField] private LaserTurret[] _laserTurrets;
        [SerializeField] private SwipeHandler _swipeHandler;
        [SerializeField] private GravityBox[] _gravityBoxes;
        [SerializeField] private InputButton _rightButton;
        [SerializeField] private InputButton _leftButton;
        [SerializeField] private CameraData _cameraData;
        [SerializeField] private MainCamera _mainCamera;
        [SerializeField] private LevelBorders _borders;
        [SerializeField] private Character _character;
        [SerializeField] private UI _ui;

        private void Awake()
        {
            CharacterGravityState characterGravityState = new(_swipeHandler);
            CharacterInput input = new InputProvider(_leftButton, _rightButton, characterGravityState).GetInput();
            PollingEvent restartEvent = new();

            _transitionsConditions.Initialize(input, _character, _borders, restartEvent.CheckIfEventHappened);
            _character.Initialize(_transitionsConditions, characterGravityState, input, _swipeHandler);
            _laserTurrets.ForEach(laserTurret => laserTurret.Initialize(characterGravityState));
            _cameraData.Initialize(_borders, characterGravityState, _character);
            _gravityBoxes.ForEach(gravityBox => gravityBox.Initialize(_swipeHandler));
            _levelStarsMediator.Resolve(characterGravityState);
            _levelResultSave.Initialize(_character.States.WinState);
            _mainCamera.Initialize(_cameraData);

            SetDependencies(new IUnityCallback[]
            {
                new LevelRestart(restartEvent.Invoke, _character.States.DieState),
                new UIHandler(_character.States, _character, _ui),
                new UIGravityBoxCover(_gravityBoxes, _ui.Find<GameplayPanel>())
            });
        }
    }
}