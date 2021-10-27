using UnityEngine;

namespace Code.Model.Visitor
{
    public readonly struct InfoCollision
    {
        private readonly Vector3 _dir;
        private readonly float _amount;
        public InfoCollision(float amount, Vector3 dir = default)
        {
            _amount = amount;
            _dir = dir;
        }
        
        public Vector3 Dir => _dir;
        public float Amount => _amount;
    }
}