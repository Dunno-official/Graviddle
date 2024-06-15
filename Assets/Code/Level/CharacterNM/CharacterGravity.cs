using Level.Gravitation;
using MonoBehaviourWrapperNM;

namespace Level.CharacterNM
{
    public class CharacterGravity : ISubscriber
    {
        private readonly IGravityState _gravityState;
        private readonly Gravity _gravity;

        public CharacterGravity(Gravity gravity, IGravityState gravityState)
        {
            _gravityState = gravityState;
            _gravity = gravity;
        }

        public void Subscribe()
        {
            _gravityState.DirectionChanged += OnGravityChanged;
        }

        public void Unsubscribe()
        {
            _gravityState.DirectionChanged -= OnGravityChanged;
        }

        private void OnGravityChanged()
        {
            _gravity.SetDirection(_gravityState.Direction);
        }
    }
}