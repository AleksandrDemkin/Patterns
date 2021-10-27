using Code.View;

namespace Code.Model.State
{
    public class StandingState : GroundedState
    {

        public StandingState(Player player, StateMachine stateMachine) : base(player, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            speed = player.MovementSpeed;
            rotationSpeed = player.RotationSpeed;
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }
    }
}