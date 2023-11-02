using UnityEngine;

namespace Assets.Scripts.Characters.Players
{
    /// <summary>
    /// Обработчик поднятия ДНК
    /// </summary>
    public class ExperiencePickup : MonoBehaviour
    {
        [SerializeField] private int amount;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Player>(out var player))
            {
                player.AddExperience(amount);
                Destroy(gameObject);
            }
        }
    }
}