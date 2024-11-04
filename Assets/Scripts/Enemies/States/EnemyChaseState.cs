using UnityEngine;

namespace Powerfish.Enemy
{
    public class EnemyChaseState : EnemyState
    {
        private bool isPlayerNearby;
        private Vector2 playerDirection;

        public EnemyChaseState(Enemy enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void DoChecks()
        {
            base.DoChecks();

            isPlayerNearby = enemy.CheckIsPlayerNearby();
            playerDirection = enemy.CheckWhichDirectionIsPlayer();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!isPlayerNearby)
            {
                enemy.stateMachine.ChangeState(enemy.idleState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            Movement?.SetVelocity(playerDirection * enemyData.movementVelocity);
            Movement?.SetRotation(playerDirection, enemyData.rotationSpeed, true);
        }
    }
}
