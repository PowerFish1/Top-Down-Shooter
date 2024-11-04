namespace Powerfish.Player
{
    public class PlayerMoveState : PlayerState
    {
        public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!isExitingState)
            {
                if (player.inputHandler.SmoothedMovementInput.magnitude <= 0.01f)
                {
                    stateMachine.ChangeState(player.idleState);
                }
            }
        }

        public override void PyhsicsUpdate()
        {
            base.PyhsicsUpdate();

            Movement?.SetVelocity(player.inputHandler.SmoothedMovementInput * playerData.movementVelocity);
            Movement?.SetRotation(player.inputHandler.SmoothedMovementInput, playerData.rotationSpeed, false);
        }
    }
}