using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.WSA;

namespace Assets.Scripts.Characters.Core.Upgrades
{
    public class UpgradesManager : MonoBehaviour
    {
        [SerializeField] private Upgrade[] upgrades;
        private List<Upgrade> availableUpgrades = new();

        private void Awake()
        {
            //ToDo for test
            availableUpgrades = upgrades.ToList();
        }

        /// <summary>
        /// Предлжить варианты прокачки
        /// </summary>
        public void Suggest()
        {
            if (availableUpgrades.Any())
            {
                // остановить скорость игры (ПАУЗА)
                Time.timeScale = 0;
            }
        }

        public void OnUpgradeApplied(Upgrade appliedUpgrade)
        {
            Time.timeScale = 1;
            if (appliedUpgrade == null)
            {
                return;
            }

            // продолжить игру
            availableUpgrades.Remove(appliedUpgrade);
        }
    }
}