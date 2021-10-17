using Asteroids.Builder;
using UnityEngine;

namespace Asteroids
{
    internal sealed class BulletBuilder
    {
        [SerializeField] private Sprite _sprite;

        private GameObject Bullet()
        {
            var gameObjectBuilder = new GameObjectBuilder();
            GameObject bullet =
                gameObjectBuilder.Visual.Name("Bullet").Sprite(_sprite).Physics.Rigidbody2D(5)
                    .BoxCollider2D();
            return bullet;
        }
    }
}