using Asteroid.Bullets.Object_Pool;
using UnityEngine;
namespace Asteroids.ServiceLocator
{
    internal sealed class ServiceLocatorExample : MonoBehaviour
    {
        private void Awake()
        {
            ServiceLocator.SetService<IService>(new Service());
        }

        private void Start()
        {
            ServiceLocator.Resolve<IService>().Test(typeof(BulletsPool));
        }
    }
}