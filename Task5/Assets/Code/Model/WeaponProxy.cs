using UnityEngine;
namespace Asteroids.Proxy.ProxyProtection
{
    public sealed class FireProxy : IFire
    {
        private static IFire _fire;
        private static UnlockFire _unlockFire;
        public FireProxy(IFire fire, UnlockFire unlockFire)
        {
            _fire = fire;
            _unlockFire = unlockFire;
        }
        public override void Fire()
        {
            if (_unlockFire.IsUnlock)
            {
                _fire.Fire();
            }
            else
            {
                Debug.Log("Weapon is lock");
            }
        }
    }
}