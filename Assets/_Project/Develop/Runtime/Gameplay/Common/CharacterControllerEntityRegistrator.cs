using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Common
{
    public class CharacterControllerEntityRegistrator : MonoEntityResgistrator
    {
        public override void Register(Entity entity)
        {
            entity.AddCharacterController(GetComponent<CharacterController>());
        }
    }
}