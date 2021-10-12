using Asteroid.Bullets.Object_Pool;
using Asteroids.Object_Pool;
using UnityEngine;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        private void Start()
        {
            Enemy.CreateAsteroidEnemy(new Health(100.0f, 100.0f));
            Enemy.CreateShipEnemy(new Health(100.0f, 100.0f));
            
            IEnemyFactory factory = new AsteroidFactory();
            factory.Create(new Health(100.0f, 100.0f));
            IEnemyFactory factory1 = new ShipFactory();
            factory1.Create(new Health(100.0f, 100.0f));

            Enemy.Factory = factory;
            Enemy.Factory = factory1;
            
            Enemy.Factory.Create(new Health(100.0f, 100.0f));
            
            EnemyPool enemyPool = new EnemyPool(5);
            var enemy = enemyPool.GetEnemy("Asteroid");
            enemy.transform.position = Vector3.one;
            enemy.gameObject.SetActive(true);
            
            BulletsPool bulletsPool = new BulletsPool(5);
            var bullet = bulletsPool.GetBullet("Bullet");
            bullet.transform.position = Vector3.one;
            bullet.gameObject.SetActive(true);
        }
    }
}
