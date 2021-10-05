using UnityEngine;

namespace Asteroids
{
    internal sealed class Fire
    {
        private readonly Rigidbody2D _bullet;
        private readonly Transform _barrel;
        private readonly float _force;

        public Fire(Rigidbody2D bullet, Transform barrel, float force)
        {
            _bullet = bullet;
            _barrel = barrel;
            _force = force;
        }

        public void Shot(Rigidbody2D rigidbody2D)
        {
            var temAmmunition = Object.Instantiate(_bullet, _barrel.position,
                _barrel.rotation);
            AddForce(temAmmunition);
        }

        private void AddForce(Rigidbody2D temAmmunition)
        {
            temAmmunition.AddForce(_barrel.up * _force);
        }
    }
}