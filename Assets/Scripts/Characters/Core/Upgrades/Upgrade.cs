using UnityEngine;

namespace Assets.Scripts.Characters.Core.Upgrades
{
    public abstract class Upgrade : MonoBehaviour
    {
        public string title;
        public Sprite icon;
        
        public abstract void Apply();
    }
}