using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature
{
    public class RigidbodyRotationSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<Vector3> _rotationDirection;
        private ReactiveVariable<float> _rotationSpeed;
        private Rigidbody _rigidbody;

        public void OnInit(Entity entity)
        {
            _rotationDirection = entity.RotationDirection;
            _rotationSpeed = entity.RotationSpeed;
            _rigidbody = entity.Rigidbody;
        }

        public void OnUpdate(float deltaTime)
        {
            Vector3 direction = _rotationDirection.Value;
            direction.y = 0f;

            if (direction.sqrMagnitude < 0.0001f)
                return;

            Quaternion target = Quaternion.LookRotation(direction);

            Quaternion next = Quaternion.RotateTowards(
                _rigidbody.rotation,
                target,
                _rotationSpeed.Value * deltaTime);

            _rigidbody.MoveRotation(next);
        }
    }
}