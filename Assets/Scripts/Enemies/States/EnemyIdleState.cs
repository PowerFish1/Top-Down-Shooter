using UnityEngine;

namespace Powerfish.Enemy
{
    public class EnemyIdleState : EnemyState
    {
        private bool isPlayerNearby;

        public EnemyIdleState(Enemy enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            Movement?.SetVelocity(Vector2.zero);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void DoChecks()
        {
            base.DoChecks();

            isPlayerNearby = enemy.CheckIsPlayerNearby();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (isPlayerNearby)
            {
                enemy.stateMachine.ChangeState(enemy.chaseState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}