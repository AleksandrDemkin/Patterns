using Asteroids.Builder;
using Asteroids.Chain_of_Responsibility;
using Asteroids.Decorator;
using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _hp;
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        
        private Camera _camera;
        private Ship _ship;
        private OnCollisionEnter _onCollisionEnter;
        private GameObjectBuilder _gameObjectBuilder;
        
        private IFire _fire;
        [Header("Start Gun")]
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrelPosition;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;

        private void Start()
        {
            _camera = Camera.main;
            var moveTransform = new MoveTransform(transform, _speed, _acceleration);
            var rotation = new RotationShip(transform);

            #region Chain_of_Responsibility
            _ship = new Ship("Player", 1, 1, moveTransform, rotation);
            
            var root = new ShipModifier(_ship);
            root.Add(new AddAttackModifierShip(_ship, 10));
            root.Add(new AddAttackModifierShip(_ship, 20));
            root.Add(new AddDefenseModifierShip(_ship, 100));
            root.Handle1();
            #endregion
            
            IAmmunition ammunition = new Bullet(_bullet, 3.0f);
            _fire = new Weapon(ammunition, _barrelPosition, 9999.0f,
                _audioSource, _audioClip);
        }
        
        private void Update()
        {
            var direction = Input.mousePosition -
                            _camera.WorldToScreenPoint(transform.position);
            _ship.Rotation(direction);
            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),
                Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }

            if (_hp <= 0)
            {
                _onCollisionEnter.Destroy();
            }
            /*else
            {
                _onCollisionEnter.HpLose();
            }*/

            if (Input.GetMouseButtonDown(0))
            {
                _fire.Fire();
            }
        }
    }
}