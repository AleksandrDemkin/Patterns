using Asteroids;
using Code.Struct_templates.Adapter.Model;
using UnityEngine;
using IFire = Asteroids.Adapter.IFire;

namespace Code.Struct_templates.Adapter
{
    internal sealed class Test : MonoBehaviour
    {
        [SerializeField]private Camera _camera;
        private IFire _fire;

        private void Awake()
        {
            _camera = Camera.main;
            _fire = new Enemy1();
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var mousePos = Input.mousePosition;
                mousePos.z = 20.0f;
                var objectPos = _camera.ScreenToWorldPoint(mousePos);
                _fire.Fire(objectPos);
            }
        }
    }
}