namespace Asteroids
{
    public sealed class Bullet
    {
        public float Max { get; }
        public float Current { get; private set; }

        public Bullet(float max, float current)
        {
            Max = max;
            Current = current;
        }

        public void ChangeCurrentBullet(float bullet)
        {
            Current = bullet;
        }
    }
}