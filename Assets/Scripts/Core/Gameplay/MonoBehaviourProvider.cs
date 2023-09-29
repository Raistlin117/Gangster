using System.Collections;
using UnityEngine;

namespace Core.Gameplay
{
    public class MonoBehaviourProvider : MonoBehaviour
    {
        public GameObject GetInstantiate(GameObject targetGameObject)
        {
            return Instantiate(targetGameObject);
        }

        public Coroutine StartProviderCoroutine(IEnumerator routine)
        {
            return StartCoroutine(routine);
        }

        public void StopProviderCoroutine(Coroutine coroutine)
        {
            StopCoroutine(coroutine);
        }
    }
}