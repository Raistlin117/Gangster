using UnityEngine;

namespace Core.Gameplay
{
    public class MonoBehaviourProvider : MonoBehaviour
    {
        public GameObject GetInstantiate(GameObject targetGameObject)
        {
            return Instantiate(targetGameObject);
        }
    }
}