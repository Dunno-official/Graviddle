using System;
using Level.Restart;
using UnityEngine;

namespace Level.LevelStar
{
    public class LevelStar : MonoBehaviour, IRestart
    {
        [SerializeField] private LevelStarImpact _levelStarImpact;
        public event Action StarCollected;
    
    
        private void OnTriggerEnter2D(Collider2D collider2d)
        {
            if (collider2d.GetComponent<Character.Character>() != null)
            {
                gameObject.SetActive(false);
            
                _levelStarImpact.Activate(transform.position);
            
                StarCollected?.Invoke();
            }
        }


        void IRestart.Restart()
        {
            gameObject.SetActive(true);
        }
    }
}
