using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono
{
    public class MonoEntity : MonoBehaviour
    {
        public void Setup(Entity entity)
        {
            MonoEntityResgistrator[] registrators = GetComponentsInChildren<MonoEntityResgistrator>();

            if(registrators != null)
                foreach (MonoEntityResgistrator registrator in registrators)
                    registrator.Register(entity);
        }

        public void Cleanup(Entity entity)
        {

        }
    }
}
