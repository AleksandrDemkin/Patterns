using Code.View;
using UnityEngine;

namespace Code.Model.State
{
    public class GroundedState : State
    {
        protected float speed;
        protected float rotationSpeed;

        private float horizontalInput;
        private float verticalInput;

        public GroundedState(Player player, StateMachine stateMachine) : base(player, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            horizontalInput = verticalInput = 0.0f;
        }

        public override void Exit()
        {
            base.Exit();
            player.ResetMoveParams();
        }

        public override void HandleInput()
        {
            base.HandleInput();
            verticalInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            player.Move(verticalInput * speed, horizontalInput * rotationSpeed);
        }
    }
}