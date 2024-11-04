using UnityEngine;
using Powerfish.CoreSystem;

namespace Powerfish.Enemy
{
    public class EnemyState
    {
        public Movement Movement
        {
            get => movement ?? core.GetCoreComponent(ref movement);
        }
        private Movement movement;

        protected Core core;
        protected Enemy enemy;
        protected EnemyStateMachine stateMachine;
        protected EnemyData enemyData;

        private string animBoolName;

        protected bool isExitingState;
        protected bool isAnimationFinished;

        protected float startTime;

        public EnemyState(Enemy enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName)
        {
            this.enemy = enemy;
            this.stateMachine = stateMachine;
            this.enemyData = enemyData;
            this.animBoolName = animBoolName;

            core = enemy.core;
        }

        public virtual void Enter()
        {
            // Do checks first time the state activates
            DoChecks();
            enemy.anim.SetBool(animBoolName, true);
            startTime = Time.time;

            isAnimationFinished = false;
            isExitingState = false;
        }

        public virtual void Exit()
        {
            enemy.anim.SetBool(animBoolName, false);
            isExitingState = true;
        }

        public virtual void DoChecks()
        {

        }

        public virtual void LogicUpdate()
        {

        }

        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }

        // Controls the animation kinda variables
        public virtual void AnimationTrigger()
        {

        }

        // Controls the variables when the animation finishes
        public virtual void AnimationFinishTrigger()
        {
            isAnimationFinished = true;
        }
    }
}
