using UnityEngine;

namespace Assets.Controllers.Players
{
    public class PlayerMoveController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;

        // Update is called once per frame
        void Update()
        {
            ProcessInputs();
        }

        void FixedUpdate()
        {
            Move();
        }

        void ProcessInputs()
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            movement = new Vector3(moveX, moveY, 0).normalized;
        }

        void Move()
        {
            transform.position += movement * moveSpeed * Time.deltaTime;
        }

        private Vector3 movement;
    }
}