using Core.Gameplay.EnemyUnits;
using UnityEngine;

namespace Core.Gameplay.PlayerUnits.Thug
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] float speed = 10f;
        [SerializeField] private int _damage = 50; //это всё так быть не должно
        
        private const string Enemy = "Enemy";

        void Start()
        {
            _rigidbody.velocity = transform.up * speed;
            
            Invoke(nameof(DisableBullet), 2);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Enemy))
            {
                DisableBullet();
                other.gameObject.GetComponent<EnemyUnitBase>().GetDamage(_damage); // говно
            }
            
            DisableBullet(); //это прикол такой)
        }

        private void DisableBullet()
        {
            gameObject.SetActive(false);
            _rigidbody.velocity = Vector2.zero;
        }
    }
}