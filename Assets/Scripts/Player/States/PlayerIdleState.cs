using UnityEngine;
using Powerfish.CoreSystem;

namespace Powerfish.Player
{
    public class PlayerIdleState : PlayerState
    {

        public PlayerIdleState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!isExitingState)
            {
                if (player.inputHandler.SmoothedMovementInput.magnitude > 0.01f)
                {
                    stateMachine.ChangeState(player.moveState);
                }
            }
        }

        public override void PyhsicsUpdate()
        {
            base.PyhsicsUpdate();

            Movement?.SetVelocity(player.inputHandler.SmoothedMovementInput * playerData.movementVelocity);
        }
    }
}