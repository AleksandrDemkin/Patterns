using Code.Struct_templates.Decorator.Interfaces;
using UnityEngine;

namespace Code.Struct_templates.Decorator.Model
{
    internal sealed class ModificationLauncher : ModificationWeapon
    {
        private readonly AudioSource _audioSource;
        private readonly ILauncher _launcher;
        private readonly Vector3 _launcherPosition;
        
        public ModificationLauncher(AudioSource audioSource, ILauncher launcher,
            Vector3 launcherPosition)
        {
            _audioSource = audioSource;
            _launcher = launcher;
            _launcherPosition = launcherPosition;
        }
        
        protected override Weapon AddModification(Weapon weapon)
        {
            var launcher = Object.Instantiate(_launcher.LauncherInstance,
                _launcherPosition, Quaternion.identity);
            weapon.SetAudioClip(_launcher.AudioClipLauncher);
            weapon.SetBarrelPosition(_launcher.BarrelPositionLauncher);
            return weapon;
        }
    }
}