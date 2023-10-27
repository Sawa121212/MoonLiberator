using System;
using UnityEngine;

namespace Assets.Sprites.Characters
{
    public class HealthPoint : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        }

        private void Awake()
        {
            Health = maxHealth;
        }

        // Update is called once per frame
        void Update()
        {
        }

        void FixedUpdate()
        {
        }

        public void Damage(int value)
        {
            Health -= value;
            Health = Math.Clamp(Health, 0, maxHealth);
            print("~" + name + " [" + "Damage: " + -1 * value + "; Health: " + Health + "]");

            if (IsDead)
            {
                gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// Здоровье
        /// </summary>
        public int Health { get; private set; }

        public bool IsDead => Health <= 0;

        public int maxHealth;
    }
}