using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle
{
    public class DeathProcessTimerSystem : IInitializableSystem
    {
        private ReactiveVariable<bool> _isDead;
        private ReactiveVariable<bool> _inDeathProcess;
        private ReactiveVariable<float> _initialTime;
        private ReactiveVariable<float> _currentTime;

        public void OnInit(Entity entity)
        {
            _isDead = entity.IsDead;
            _inDeathProcess = entity.InDeathProcess;
            _initialTime = entity.DeathProcessInitialTime;
            _currentTime = entity.DeathProcessCurrentTime;
        }
    }
}
