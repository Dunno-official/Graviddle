using System;
using Cysharp.Threading.Tasks;
using Extensions;
using Level.UserInterface.Panels;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Level.UserInterface
{
    public class UI : MonoBehaviour
    {
        [SerializeField] [ChildGameObjectsOnly] private Panel[] _states;
        [SerializeField] [ChildGameObjectsOnly] private Panel _initialPanel;
        private Panel _current;

        public async UniTask Initialize()
        {
            foreach (Panel panel in _states)
            {
                await panel.Initialize();
            }

            await Show(_initialPanel);
        }

        public async void ShowSync(Panel panel) // editor button
        {
            await Show(panel);
        }
    
        public async UniTask Show<T>() where T : Panel
        {
            await Show(Find<T>());
        }
    
        private async UniTask Show(Panel panel)
        {
            if (_current != null)
            {
                await _current.Hide();
            }
        
            await panel.Show();
        
            _current = panel;
        }
    
        public void DisableAll()
        {
            _states.ForEach(state => state.Disable());
        }

        public T Find<T>() where T : Panel
        {
            foreach (Panel uiState in _states)
            {
                if (uiState is T result)
                {
                    return result;
                }
            }

            throw new Exception("No such ui component");
        }
    }
}