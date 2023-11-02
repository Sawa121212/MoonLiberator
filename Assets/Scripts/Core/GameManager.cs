using UnityEngine;

namespace Assets.Scripts.Core
{
    public class GameManager : MonoBehaviour
    {
        public GameObject GameOverPanel;
        public Player Player;
        public Enemy[] Enemies;

        private void Update()
        {
            if (!Player.IsDead)
            {
                return;
            }

            foreach (var enemy in Enemies)
            {
                if (enemy is null)
                {
                    return;
                }

                enemy.enabled = false;
            }

            GameOverPanel.SetActive(true);
        }
    }
}