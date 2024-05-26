using Level.Character.CharacterMovement.CharacterInputNM;
using Level.Character.Helpers;
using UnityEngine;
using Utils.Physics;

namespace Level.Character.CharacterStateMachine.States
{
    public class RunState : CharacterState
    {
        private readonly CircleCast<Ground> _circleCast;
        private readonly CircleCastData _castData;
        private readonly Rigidbody2D _rigidbody;
        private readonly CharacterInput _input;
        private readonly float _movementSpeed;

        public RunState(Animator character, CharacterInput input, float speed, CircleCastData castData) : base(character, AnimationsName.Run)
        {
            _rigidbody = character.GetComponent<Rigidbody2D>();
            _circleCast = new CircleCast<Ground>(4, castData);
            _movementSpeed = speed;
            _castData = castData;
            _input = input;
        }

        public override void Update()
        {
            Vector2 slopeNormal = GetSlopeNormal();
            _rigidbody.velocity = EvaluateVelocity(slopeNormal, _input.GetDirection());
        }

        private Vector2 GetSlopeNormal()
        {
            HitResult<Ground> result = _circleCast.Fetch(_rigidbody.position, -_rigidbody.transform.up);

            return result.Success ? result.Hit.normal : Vector2.zero;
        }

        private Vector3 EvaluateVelocity(Vector3 slopeNormal, Vector3 localDirection)
        {
            return Vector3.Cross(Vector3.Cross(slopeNormal, localDirection), slopeNormal).normalized * _movementSpeed;
        }

        public override void DrawGizmo()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_rigidbody.position, _castData.Radius);
            Gizmos.DrawWireSphere(_rigidbody.position - (Vector2)_rigidbody.transform.up * _castData.Distance, _castData.Radius);
        }
    }
}