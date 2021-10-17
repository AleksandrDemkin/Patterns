using Code.Struct_templates.Decorator.Interfaces;
using UnityEngine;

namespace Code.Struct_templates.Decorator.Model
{
    internal sealed class Launcher : ILauncher
    {
        public AudioClip AudioClipLauncher { get; }
        public Transform BarrelPositionLauncher { get; }
        public GameObject LauncherInstance { get; }
        
        public Launcher(AudioClip audioClipLauncher, Transform barrelPositionLauncher,
            GameObject launcherInstance)
        {
            AudioClipLauncher = audioClipLauncher;
            BarrelPositionLauncher = barrelPositionLauncher;
            LauncherInstance = launcherInstance;
        }
    }
}