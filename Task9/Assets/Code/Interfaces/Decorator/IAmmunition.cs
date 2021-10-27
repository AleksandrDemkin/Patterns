using UnityEngine;

namespace Code.Interfaces.Decorator
{
    internal interface IAmmunition
    {
        Rigidbody2D BulletInstance { get; }
        float TimeToDestroy { get; }
    }
}