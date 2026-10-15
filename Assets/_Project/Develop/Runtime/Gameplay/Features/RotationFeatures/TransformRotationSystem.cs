using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature
{
    public class TransformRotationSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<Vector3> _rotationDirection;
        private ReactiveVariable<float> _rotationSpeed;
        private Transform _transform;

        public void OnInit(Entity entity)
        {
            _rotationDirection = entity.RotationDirection;
            _rotationSpeed = entity.RotationSpeed;
            _transform = entity.Transform;
        }

        public void OnUpdate(float deltaTime)
        {
            Vector3 direction = _rotationDirection.Value;
            direction.y = 0f;

            if (direction.sqrMagnitude < 0.0001f)
                return;

            Quaternion target = Quaternion.LookRotation(direction);

            _transform.rotation = Quaternion.RotateTowards(
                _transform.rotation,
                target,
                _rotationSpeed.Value * deltaTime);
        }
    }
}