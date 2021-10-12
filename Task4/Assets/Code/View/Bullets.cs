using System;
using Asteroids.Object_Pool;
using UnityEngine;

namespace Asteroids
{
    public abstract class Bullets : MonoBehaviour
    {
        private Transform _rotPool;
        private Bullets _bullets;
        public double Current { get; }
        
        public Bullets Bullet
        {
            get
            {
                if (_bullets.Current <= 0.0f)
                {
                    ReturnToPool();
                }
                return _bullets;
            }
            protected set => _bullets = value;
        }
        public Transform RotPool
        {
            get
            {
                if (_rotPool == null)
                {
                    var find = GameObject.Find(NameManager.POOL_AMMUNITION);
                    _rotPool = find == null ? null : find.transform;
                }
                return _rotPool;
            }
        }
        public static Bullets CreateAsteroidBullet(Bullets hp)
        {
            var bullet = Instantiate(Resources.Load<Bullets>("Enemy/Asteroid"));
            bullet.Bullet = bullet;
            return bullet;
        }
        public void DependencyInjectBullet(Bullets bullet)
        {
            Bullet = bullet;
        }
        public void ActiveBullet(Vector3 position, Quaternion rotation)
        {
            transform.localPosition = position;
            transform.localRotation = rotation;
            gameObject.SetActive(true);
            transform.SetParent(null);
        }
        protected void ReturnToPool()
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(false);
            transform.SetParent(RotPool);
            if (!RotPool)
            {
                Destroy(gameObject);
            }
        }
    }
}