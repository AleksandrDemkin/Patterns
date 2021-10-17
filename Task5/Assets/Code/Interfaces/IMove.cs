namespace Asteroids
{
    public interface IMove
    {
        float Speed { get; }
        void Move(float horizintal, float vertical, float deltaTime);
    }
}