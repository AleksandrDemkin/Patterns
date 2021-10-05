
using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _hp;
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;
        
        private Camera _camera;
        private Ship _ship;
        private Fire _fire;
        private OnCollisionEnter _onCollisionEnter;

        private void Start()
        {
            _camera = Camera.main;
            var moveTransform = new AccelerationMove(transform, _speed,
                _acceleration);
            var rotation = new RotationShip(transform);
            _ship = new Ship(moveTransform, rotation);
        }
        
        private void Update()
        {
            var direction = Input.mousePosition -
                            _camera.WorldToScreenPoint(transform.position);
            _ship.Rotation(direction);
            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),
                Time.deltaTime);
            var temAmmunition = Instantiate(_bullet, _barrel.position,
                _barrel.rotation);
            temAmmunition.AddForce(_barrel.up * _force);
            
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
            else
            {
                _onCollisionEnter.HpLose();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                _fire.Shot(temAmmunition);
            }
        }
    }
}