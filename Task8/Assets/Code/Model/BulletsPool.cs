using System;
using System.Collections.Generic;
using System.Linq;
using Asteroids.Object_Pool;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroid.Bullets.Object_Pool
{
    internal sealed class BulletsPool
    {
        private readonly Dictionary<string, HashSet<Asteroids.Bullets>> _bulletPool;
        private readonly int _capacityPool;
        private Transform _rootPool;
        public BulletsPool(int capacityPool)
        {
            _bulletPool = new Dictionary<string, HashSet<Asteroids.Bullets>>();
            _capacityPool = capacityPool;
            if (!_rootPool)
            {
                _rootPool = new
                    GameObject(NameManager.POOL_BULLETS).transform;
            }
        }
        public Asteroids.Bullets GetBullet(string type)
        {
            Asteroids.Bullets result;
            switch (type)
            {
                case "Bullet":
                    result = GetBullet(GetListBullets(type));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type,
                        "Не предусмотрен в программе");
            }
            return result;
        }

        private HashSet<Asteroids.Bullets> GetListBullets(string type)
        {
            return _bulletPool.ContainsKey(type) ? _bulletPool[type] :
                _bulletPool[type] = new HashSet<Asteroids.Bullets>();
        }
        private Asteroids.Bullets GetBullet(HashSet<Asteroids.Bullets> bullets)
        {
            var bullet = bullets.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (bullet == null )
            {
                var laser = Resources.Load<Asteroids.Bullets>("Enemy/Bullet");
                for (var i = 0; i < _capacityPool; i++)
                {
                    var instantiate = Object.Instantiate(laser);
                    ReturnToPool(instantiate.transform);
                    bullets.Add(instantiate);
                }
                GetBullet(bullets);
            }
            bullet = bullets.FirstOrDefault(a => !a.gameObject.activeSelf);
            return bullet;
        }
        private void ReturnToPool(Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(_rootPool);
        }
        public void RemovePool()
        {
            Object.Destroy(_rootPool.gameObject);
        }
    }
}