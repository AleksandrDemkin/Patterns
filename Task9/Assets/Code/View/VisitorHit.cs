using Code.Interfaces.Visitor;
using UnityEngine;

namespace Code.View
{
    public abstract class VisitorHit : MonoBehaviour
    {
        public float Health;
        public TextMesh TextMesh;
        public abstract void Activate(IDealingEnemy value, float amount);
    }
}