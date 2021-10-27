using System;
using Code.Interfaces.Visitor;
using Code.View;
using UnityEngine;

namespace Code.Model.Visitor
{
    public sealed class ConsoleDisplay : IDealingEnemy
    {
        public void Visit(VisitorEnemy hit, InfoCollision info)
        {
            Debug.Log($"{nameof(VisitorEnemy)} - {info.Amount}");
        }
        
        public void Visit(VisitorEnvironment hit, InfoCollision info)
        {
            Debug.Log($"{nameof(VisitorEnvironment)} - {info.Amount}");
        }
    }
}