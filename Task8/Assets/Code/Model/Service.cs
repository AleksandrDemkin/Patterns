using UnityEngine;

namespace Asteroids.ServiceLocator
{
    internal sealed class Service : IService
    {
        public void Test()
        {
            throw new System.NotImplementedException();
        }

        public void Test(object bulletsPool)
        {
            Debug.Log(nameof(Service));
        }
    }
}