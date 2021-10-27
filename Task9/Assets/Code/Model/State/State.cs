using Code.View;

namespace Code.Model.State
{
    public abstract class State
    {
        public Player Player { get; set; }
        protected StateMachine stateMachine;

        protected State(Player player, StateMachine stateMachine)
        {
            Player = player;
            this.stateMachine = stateMachine;
        }

        protected void DisplayOnUI(UIManager.Alignment alignment)
        {
            UIManager.Instance.Display(this, alignment);
        }

        public virtual void Enter()
        {
            DisplayOnUI(UIManager.Alignment.Left);
        }

        public virtual void HandleInput()
        {

        }

        public virtual void LogicUpdate()
        {

        }

        public virtual void PhysicsUpdate()
        {

        }

        public virtual void Exit()
        {

        }
    }
}