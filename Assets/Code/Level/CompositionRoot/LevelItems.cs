using System.Linq;
using Extensions;
using Level.Gravitation;
using Level.Gravitation.GravityButton;
using Level.Gravitation.SwipeHandlerNM;
using Level.GravityBoxNM;
using Level.Obstacles;
using UnityEngine;

namespace Level
{
    public class LevelItems
    {
        private readonly GravityButton[] _gravityButtons;
        private readonly LaserTurret[] _laserTurrets;
        public readonly GravityBox[] GravityBoxes;

        public LevelItems()
        {
            MonoBehaviour[] monoBehaviours = Object.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);
            _gravityButtons = monoBehaviours.OfType<GravityButton>().ToArray();
            _laserTurrets = monoBehaviours.OfType<LaserTurret>().ToArray();
            GravityBoxes = monoBehaviours.OfType<GravityBox>().ToArray();
        }
        
        public void InitializeTurrets(IGravityState characterGravityState)
        {
            _laserTurrets.ForEach(laserTurret => laserTurret.Initialize(characterGravityState));
        }

        public void InitializeGravityBoxes(SwipeHandler swipeHandler)
        {
            GravityBoxes.ForEach(gravityBox => gravityBox.Initialize(swipeHandler));
        }

        public void InitializeGravityButtons()
        {
            _gravityButtons.ForEach(button => button.Initialize());
        }
    }
}