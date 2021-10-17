using Code.Struct_templates.Bridge.Interfaces;
using UnityEngine;

namespace Code.Struct_templates.Bridge.Model
{
    internal sealed class MagicalAttack : IAttack
    {
        public void Attack(Vector3 position)
        {
            var bullet = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            bullet.name = "Magic Bullet";
            bullet.transform.position = position;
        }
    }
}