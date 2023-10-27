using UnityEngine;

namespace Assets.Scripts.Core
{
    public class CameraLinker : MonoBehaviour
    {
        public GameObject linkedObject;
        private Vector3 offset;

        void Start()
        {
            offset = transform.position;
        }

        void LateUpdate()
        {
            transform.position = linkedObject.transform.position + offset;
        }
    }
}