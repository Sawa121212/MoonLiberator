using System.Collections.Generic;
using System.Linq;
using Assets.Sprites.Characters;
using UnityEngine;

public class Player : HealthPoint
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        Move();
        Shoot();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        movement = new Vector3(moveX, moveY, 0).normalized;
    }

    void Move()
    {
        transform.position += movement * speed * Time.deltaTime;
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
        Enemy closesEnemy = null;

        float minDistance = float.MaxValue;

        foreach (var enemy in enemies.Where(e => e.IsDead == false))
        {
            float distance = (enemy.transform.position - transform.position).magnitude;

            if (distance < minDistance)
            {
                minDistance = distance;
                closesEnemy = enemy;
            }
        }

        return closesEnemy;
    }


    /// <summary>
    /// Пуля
    /// </summary>
    public GameObject bulletPrefab;

    /// <summary>
    /// Дальность стрельбы
    /// </summary>
    public float shootingRange;

    /// <summary>
    /// Перезарядка стрельбы
    /// </summary>
    public float reloadShooting;

    /// <summary>
    /// Скорость пули
    /// </summary>
    public float bulletSpeed;

    public float speed;
    private Vector3 movement;
    private float shootingInterval;

    public List<Enemy> enemies;
}