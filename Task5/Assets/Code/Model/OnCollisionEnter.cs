using Asteroids.Fasade;
using UnityEngine;

namespace Asteroids
{
    internal abstract class OnCollisionEnter
    {
        private readonly Player _player;
        private float _hp;

        protected OnCollisionEnter(Player player)
        {
            _player = player;
        }

        internal void HpLose()
        {
            
            var f = _hp--;
        }

        internal void Destroy()
        {
            Object.Destroy(_player.gameObject);
        }
    }
}