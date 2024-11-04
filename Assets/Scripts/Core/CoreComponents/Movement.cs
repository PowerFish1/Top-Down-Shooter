using UnityEngine;

namespace Powerfish.CoreSystem
{
    public class Movement : CoreComponent
    {
        private Rigidbody2D rb;

        public Vector2 CurrentVelocity { get; private set; }
        private Vector2 workspace;


        protected override void Awake()
        {
            base.Awake();

            rb = GetComponentInParent<Rigidbody2D>();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            CurrentVelocity = rb.velocity;
        }

        public void SetVelocity(Vector2 velocity)
        {
            workspace.Set(velocity.x, velocity.y);
            SetFinalVelocity();
        }

        public void SetFinalVelocity()
        {
            rb.velocity = workspace;
            CurrentVelocity = workspace;
        }

        public void SetRotation(Vector2 direction, float rotationSpeed, bool isEnemy)
        {
            float viewAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            if (isEnemy)
            {
                viewAngle -= 90f;
            }

            Quaternion targetRotation = Quaternion.Euler(0, 0, viewAngle);

            rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime));
        }


    }
}