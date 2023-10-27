using UnityEngine;

namespace Assets.Sprites.Characters
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
            
            // проверяем Tag объекта. Если они совподаю, значит однотипные
            bool isFriend = collision.CompareTag(tag);
            if (hasHealth && !isFriend)
            {
                character.Damage(damage);
            }
        }

        public int damage;
    }
}