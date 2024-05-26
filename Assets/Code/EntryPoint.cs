using Extensions;
using Level.Camera;
using Level.Camera.Clamping.Data;
using Level.Character;
using Level.Character.CharacterMovement.CharacterInputNM;
using Level.Character.CharacterStateMachine;
using Level.Character.CharacterStateMachine.StateTransitions;
using Level.Gravitation;
using Level.Gravitation.SwipeHandler;
using Level.GravityBox;
using Level.LevelStar;
using Level.Obstacles;
using Level.Restart;
using Level.UI;
using Level.UI.Panels.GameplayPanel.MovementButtons;
using MonoBehaviourWrapper;
using SaveSystm;
using UnityEngine;

public class EntryPoint : MonoBehaviourWrapper.MonoBehaviourWrapper
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
        CharacterStatesPresenter states = new(_character.GetComponent<Animator>(), input);
        TransitionsPresenterFactory transitionsPresenterFactory = new(states, _transitionsConditions);
        TransitionsPresenter transitionsPresenter = transitionsPresenterFactory.Create();
        PollingEvent restartEvent = new();

        _transitionsConditions.Initialize(input, _character, _borders, restartEvent.CheckIfEventHappened);
        _character.Initialize(transitionsPresenter, states, _swipeHandler, characterGravityState, input);
        _laserTurrets.ForEach(laserTurret => laserTurret.Initialize(characterGravityState));
        _cameraData.Initialize(_swipeHandler, _borders, characterGravityState, _character);
        _gravityBoxes.ForEach(gravityBox => gravityBox.Initialize(_swipeHandler));
        _levelStarsMediator.Resolve(characterGravityState);
        _levelResultSave.Initialize(states.WinState);
        _mainCamera.Initialize(_cameraData);

        SetDependencies(new IUnityCallback[]
        {
            new LevelRestart(restartEvent.Invoke, states.DieState),
            new UIHandler(states, _character, _ui),
        });
    }
}