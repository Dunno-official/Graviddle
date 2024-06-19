using MonoBehaviourWrapperNM;
using UnityEngine;

namespace Level.Gravitation.GravityButtonNM
{
    public class GravityButtonPressFeedback : ISubscriber
    {
        private readonly GravityButtonEvents _events;
        private readonly AudioSource _audio;

        public GravityButtonPressFeedback(GravityButtonEvents events, AudioSource audio)
        {
            _events = events;
            _audio = audio;
        }

        public void Subscribe()
        {
            _events.Toggled += PlayFeedback;
        }

        public void Unsubscribe()
        {
            _events.Toggled -= PlayFeedback;
        }

        private void PlayFeedback(bool state)
        {
            _audio.Play();
        }
    }
}