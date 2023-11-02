using UnityEngine;

namespace Assets.Scripts.Characters.Core
{
    public class Damager : MonoBehaviour
    {
        void Update()
        {
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // проверяем, живой ли объект
            bool hasHealth = collision.TryGetComponent<HealthPoint>(out var character);
            if (!hasHealth)
                return;

            if (character is HealthPoint _healthPoint && _healthPoint.IsDead)
                return;

            // проверяем Tag объекта. Если они совподаю, значит однотипные
            bool isFriend = collision.CompareTag(tag);
            if (hasHealth && !isFriend)
            {
                character.Damage(damage);
                if (destroyOnHit)
                {
                    Destroy(gameObject);
                }
            }
        }

        /// <summary>
        /// Сила урона
        /// </summary>
        public int damage;
        
        /// <summary>
        /// При нанесении урона, объект удаляется
        /// </summary>
        public bool destroyOnHit;
    }
}