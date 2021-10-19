using UnityEngine;

namespace Asteroids
{
    public sealed class Ship : IMove, IRotation
    {
        private readonly IMove _moveImplementation;
        private readonly IRotation _rotationImplementation;
        public string Name;
        public int Attack;
        public int Defense;
        
        public float Speed => _moveImplementation.Speed;
        public Ship(string name, int attack, int defense, IMove moveImplementation, IRotation rotationImplementation)
        {
            Name = name;
            Attack = attack;
            Defense = defense;
            _moveImplementation = moveImplementation;
            _rotationImplementation = rotationImplementation;
        }
        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _moveImplementation.Move(horizontal, vertical, deltaTime);
        } 
        public void Rotation(Vector3 direction)
        {
            _rotationImplementation.Rotation(direction);
        }
        public void AddAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.AddAcceleration();
            }
        }
        public void RemoveAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.RemoveAcceleration();
            }
        }
    }
}