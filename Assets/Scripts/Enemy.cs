using Assets.Scripts.Characters.Core;
using Assets.Scripts.Characters.Players;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts
{
    public class Enemy : HealthPoint
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private ExperiencePickup pickup;
        [SerializeField] public EnemiesSpawner EnemiesSpawnerModel;
        
        // Start is called before the first frame update
        void Start()
        {
            player = FindObjectOfType<Player>()?.transform;
        }

        // Update is called once per frame
        void Update()
        {
            if (IsDead || player == null)
            {
                return;
            }

            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
            GetComponent<SpriteRenderer>().flipX = direction.x < 0;
        }

        protected override void OnDead()
        {
            Instantiate(pickup, transform.position, quaternion.identity);
            EnemiesSpawnerModel.OnEnemyDead(this);
        }


        private Transform player;
    }
}