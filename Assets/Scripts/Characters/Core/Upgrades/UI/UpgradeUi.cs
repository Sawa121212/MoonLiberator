using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Characters.Core.Upgrades.UI
{
    public class UpgradeUi : MonoBehaviour
    {
        [SerializeField] private Text title;
        [SerializeField] private Image icon;

        public void Setup(string title, Sprite icon, Action onApply)
        {
            this.title.text = title;
            this.icon.sprite = icon;
            this.applyAction = onApply;
        }

        public void Apply()
        {
        }

        private Action applyAction;
    }
}