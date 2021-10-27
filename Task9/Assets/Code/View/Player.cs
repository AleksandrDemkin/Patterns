using Code.Interfaces.Decorator;
using Code.Model;
using Code.Model.Decorator;
using Code.Model.State;
using Code.Model.Visitor;
using UnityEngine;

namespace Code.View
{
    public sealed class Player : MonoBehaviour
    {
        [SerializeField] private static float _speed;
        private static readonly Transform _transform;
        
        private Camera _camera;
        private Ship _ship;
        private Health _hp;
        
        public StateMachine movementSM;
        public StandingState standing;
        
        private IFire _fire;
        [Header("Start Gun")]
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrelPosition;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        
        public float Amount;
        private float _dedicateDistance = 20.0f;
        
        private void Start()
        {
            movementSM = new StateMachine();
            standing = new StandingState(this, movementSM);
            movementSM.Initialize(standing);

            _camera = Camera.main;
            _hp = new Health(100.0f, 100.0f);
            
            var ammunition = new Bullet(_bullet, 3.0f);
            _fire = new Weapon(ammunition, _barrelPosition, 999.0f,
                _audioSource, _audioClip);
        }
        
        private void Update()
        {
            movementSM.CurrentState.HandleInput();
            movementSM.CurrentState.LogicUpdate();
            
            if (Input.GetMouseButtonDown(0))
            {
                _fire.Fire();
                
                if
                (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition),
                    out var hit, _dedicateDistance))
                {
                    if (hit.collider.TryGetComponent<VisitorHit>(out var damage))
                    {
                        damage.Activate(new ConsoleDisplay(), Amount);
                    }
                }
            }
        }
        
        private void FixedUpdate()
        {
            movementSM.CurrentState.PhysicsUpdate();
        }
        
        public void Move(float speed, float rotationSpeed)
        {
            Vector3 targetVelocity = speed * transform.forward * Time.deltaTime;
            targetVelocity.y = GetComponent<Rigidbody>().velocity.y;
            GetComponent<Rigidbody>().velocity = targetVelocity;

            GetComponent<Rigidbody>().angularVelocity = rotationSpeed * Vector3.up * Time.deltaTime;
        }

        public void ResetMoveParams()
        {
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
        private void OnCollisionEnter2D()
        {
            if (_hp.Current <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _hp.Current--;
            }
        }
    }
}