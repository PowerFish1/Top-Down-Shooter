using UnityEngine;
using Powerfish.CoreSystem;

namespace Powerfish.Player
{
    public class PlayerState
    {
        public Movement Movement
        {
            get => movement ?? core.GetCoreComponent(ref movement);
        }
        private Movement movement;


        protected Player player;
        protected PlayerStateMachine stateMachine;
        protected PlayerData playerData;
        protected Core core;

        protected bool isExitingState;
        protected bool isAnimationFinished;

        protected float startTime;

        private string animBoolName; // controlling animations with their names

        public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
        {
            this.player = player;
            this.stateMachine = stateMachine;
            this.playerData = playerData;
            this.animBoolName = animBoolName;

            core = player.core;
        }

        // When the players state is Entered
        public virtual void Enter()
        {
            // Do checks first time the state activates
            DoChecks();
            player.anim.SetBool(animBoolName, true);
            startTime = Time.time;

            isAnimationFinished = false;
            isExitingState = false;
        }

        // When the players state is Exited
        public virtual void Exit()
        {
            player.anim.SetBool(animBoolName, false);
            isExitingState = true;
        }

        // Doing checks for environment and controls variables bool
        public virtual void DoChecks()
        {

        }

        // Controls players states logic
        public virtual void LogicUpdate()
        {
        }

        // Controls the pyhsics logic
        public virtual void PyhsicsUpdate()
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