using Asteroids.Adapter;
using UnityEngine;
using Code.Struct_templates.Adapter.Interfaces;

namespace Code.Struct_templates.Adapter.Model
{
    internal sealed class Enemy1 : IFire
    {
        private readonly IAttack _attack = new AttackBullet();
        
        public void Fire(Vector3 position)
        {
            _attack.Attack(position);
        }
    }
}