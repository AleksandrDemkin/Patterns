using Code.Struct_templates.Bridge.Interfaces;
using UnityEngine;

namespace Code.Struct_templates.Bridge.Model
{
    internal sealed class ShotAttack : IAttack
    {
        public void Attack(Vector3 position)
        {
            var bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            bullet.name = "Bullet";
            bullet.transform.position = position;
        }
    }
}