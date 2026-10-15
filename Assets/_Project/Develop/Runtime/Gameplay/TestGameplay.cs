using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay
{
    public class TestGameplay : MonoBehaviour
    {
        private DIContainer _container;
        private EntitiesFactory _entitiesFactory;

        private Entity _entity;

        private bool _isRunning;

        public void Initialize(DIContainer container)
        {
            _container = container;
            _entitiesFactory = _container.Resolve<EntitiesFactory>();
        }

        public void Run()
        {
            _entity = _entitiesFactory.CreateGhost(Vector3.zero);

            _isRunning = true;
        }

        private void Update()
        {
            if (_isRunning == false)
                return;

            if(Input.GetKeyDown(KeyCode.Space))
            {
                _entity.CurrentHealth.Value -= 50;
                Debug.Log("Current Health: " + _entity.CurrentHealth.Value.ToString());
            }

            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

            _entity.MoveDirection.Value = input;
            _entity.RotationDirection.Value = input;
        }
    }
}
