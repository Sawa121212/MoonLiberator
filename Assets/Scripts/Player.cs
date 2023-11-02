using System;
using System.Linq;
using Assets.Scripts.Characters.Core;
using Assets.Scripts.Characters.Core.Upgrades;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : HealthPoint
    {
        /// <summary>
        /// Пуля
        /// </summary>
        [SerializeField] private GameObject bulletPrefab;

        /// <summary>
        /// Дальность стрельбы
        /// </summary>
        [SerializeField] private float shootingRange;

        /// <summary>
        /// Перезарядка стрельбы
        /// </summary>
        [SerializeField] private float reloadShooting;

        /// <summary>
        /// Скорость пули
        /// </summary>
        [SerializeField] private float bulletSpeed;

        [SerializeField] private EnemiesSpawner enemiesSpawner;
        [SerializeField] private UpgradesManager upgradeManager;

        /// <summary>
        /// Уровни опыта
        /// </summary>
        [SerializeField] private int[] experiencesLevels;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        void FixedUpdate()
        {
            Shoot();
        }

        void Shoot()
        {
            shootingInterval += Time.deltaTime;

            if (shootingInterval >= reloadShooting)
            {
                shootingInterval = 0f;

                // Найти ближайшего врага
                Enemy closestEnemy = FindClosestEnemy();
                if (closestEnemy is null)
                {
                    return;
                }

                // создаем пулю
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                Rigidbody2D bulletRigidBody = bullet.GetComponent<Rigidbody2D>();

                Vector3 direction = (closestEnemy.transform.position - transform.position).normalized;
                bulletRigidBody.AddForce(direction * bulletSpeed);
            }
        }

        /// <summary>
        /// Найти ближайшего врага
        /// </summary>
        /// <returns></returns>
        Enemy FindClosestEnemy()
        {
            if (enemiesSpawner?.SpawnedEnemies == null || !enemiesSpawner.SpawnedEnemies.Any())
                return null;

            Enemy closesEnemy = null;

            float minDistance = float.MaxValue;

            foreach (var enemy in enemiesSpawner.SpawnedEnemies.Where(e => e.IsDead == false))
            {
                float distance = (enemy.transform.position - transform.position).magnitude;

                if (distance < minDistance && distance < shootingRange)
                {
                    minDistance = distance;
                    closesEnemy = enemy;
                }
            }

            return closesEnemy;
        }

        public void AddExperience(int value)
        {
            experience += value;
            var newLevel = Array.FindLastIndex(experiencesLevels, e => experience >= e);
            Debug.Log("Player Level: " + newLevel + ", Exp: " + experience);

            if (newLevel > currentLevel)
            {
                currentLevel = newLevel;
                upgradeManager.Suggest();
            }
        }

        // Test
        [ContextMenu("AddExperience")]
        void AddExperience()
        {
            AddExperience(5);
        }
        
        // Test
        [ContextMenu("ResetExperience")]
        void ResetExperience()
        {
            currentLevel = experience = 0;
        }

        private float shootingInterval;
        private int currentLevel;
        private int experience;
    }
}