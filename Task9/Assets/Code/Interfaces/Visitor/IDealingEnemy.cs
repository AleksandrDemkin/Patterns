using System;
using Code.Model.Visitor;

namespace Code.Interfaces.Visitor
{
    public interface IDealingEnemy
    {
        void Visit(VisitorEnemy hit, InfoCollision info);
        void Visit(VisitorEnvironment hit, InfoCollision info);
    }
}