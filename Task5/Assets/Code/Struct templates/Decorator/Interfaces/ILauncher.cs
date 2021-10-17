using UnityEngine;

namespace Code.Struct_templates.Decorator.Interfaces
{
    internal interface ILauncher
    {
        AudioClip AudioClipLauncher { get; }
        Transform BarrelPositionLauncher { get; }
        GameObject LauncherInstance { get; }
    }
}