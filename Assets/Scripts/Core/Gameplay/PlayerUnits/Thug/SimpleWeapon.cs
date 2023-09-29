using UnityEngine;

namespace Core.Gameplay.PlayerUnits.Thug
{
    public class SimpleWeapon : MonoBehaviour
    {
        [SerializeField] LayerMask _enemyLayer = 7;
        [SerializeField] private Transform[] _bulletPool; //ужас
        [SerializeField] private float _distance = 1f;
        [SerializeField] private float _frequency = 5f;

        private int _bulletIndex;
        private bool _canHint = true;

        private void Update()
        {
            if (!_canHint) return;
            
            Vector2 playerPosition = transform.position;

            Vector2 rayDirection = Vector2.up;

            Ray2D ray = new Ray2D(playerPosition, rayDirection);

            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, _distance, _enemyLayer);

            if (hit.collider != null)
            {
                _canHint = false;
                
                _bulletPool[_bulletIndex].gameObject.SetActive(true);

                _bulletIndex = _bulletIndex == _bulletPool.Length ? 0 : _bulletIndex++;

                _bulletIndex++;
                
                Invoke(nameof(ResetCanHint), _frequency);
            }
        }

        private void ResetCanHint()
        {
            _canHint = true;
        }
        private void OnDrawGizmos()
        {
            Vector2 playerPosition = transform.position;

            Vector2 rayDirection = Vector2.up;

            Gizmos.color = Color.red;
            Gizmos.DrawRay(playerPosition, rayDirection * _distance);
        }
    }
}