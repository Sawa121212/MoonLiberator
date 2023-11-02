using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Characters.Core.Upgrades.UI
{
    public class UpgradeUiManger : MonoBehaviour
    {
        [SerializeField] private UpgradeUi upgradeUiPrefab;
        [SerializeField] private UpgradesManager upgradesManager;

        public void Show(List<Upgrade> upgrades)
        {
            gameObject.SetActive(false);

            foreach (var upgrade in upgrades)
            {
                var ui = Instantiate(upgradeUiPrefab);
                ui.Setup(upgrade.title, upgrade.icon, () => OnClickApply(upgrade));
            }
        }

        public void Hide()
        {
        }

        void OnClickApply(Upgrade upgrade)
        {
            upgrade.Apply();
            upgradesManager.OnUpgradeApplied(upgrade);
        }
    }
}