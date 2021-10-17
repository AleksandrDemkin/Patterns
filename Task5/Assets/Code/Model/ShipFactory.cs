using Asteroid;
using UnityEngine;
namespace Asteroids
{
    internal sealed class ShipFactory : IEnemyFactory
    {
        public Enemy Create(Health hp)
        {
            var enemy =
                Object.Instantiate(Resources.Load<ShipEnemy>("Enemy/Asteroid"));
            enemy.DependencyInjectHealth(hp);
            return enemy;
        }
    }
}