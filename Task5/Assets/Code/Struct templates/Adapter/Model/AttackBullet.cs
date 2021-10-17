using Code.Struct_templates.Adapter.Interfaces;
using UnityEngine;

namespace Code.Struct_templates.Adapter.Model
{
    internal sealed class AttackBullet : IAttack
    {
        public void Attack(Vector3 position)
        {
            var bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            bullet.name = "Bullet";
            bullet.transform.position = position;
        }
    }
}