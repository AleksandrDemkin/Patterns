using Code.Interfaces.Visitor;
using Code.View;

namespace Code.Model.Visitor
{
    public sealed class VisitorEnemy : VisitorHit
    {
        public override void Activate(IDealingEnemy value, float amount)
        {
            value.Visit(this, new InfoCollision(amount));
        }
    }
}