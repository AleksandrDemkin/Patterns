using Code.Struct_templates.Decorator.Interfaces;
using UnityEngine;

namespace Code.Struct_templates.Decorator.Model
{
    internal abstract class ModificationWeapon : IFire
    {
        private Weapon _weapon;
        protected abstract Weapon AddModification(Weapon weapon);
        
        public void ApplyModification(Weapon weapon)
        {
            _weapon = AddModification(weapon);
        }
        
        public void Fire()
        {
            _weapon.Fire();
        }

        public void FireGranage()
        {
            _weapon.FireGranage();
        }
    }
}