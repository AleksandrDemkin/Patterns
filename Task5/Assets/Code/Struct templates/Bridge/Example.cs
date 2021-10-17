using System;
using Code.Struct_templates.Bridge.Model;
using UnityEngine;

namespace Code.Struct_templates.Bridge
{
    internal sealed class Example : MonoBehaviour
    {
        private Camera _camera;
        private Unit _unitMagic;
        private Unit _enemyMagicFly;
        private Unit _unitShot;
        private Unit _enemyFly;
        private Unit _enemyJump;
        private void Awake()
        {
            _camera = Camera.main;
            _unitMagic = new Unit(new MagicalAttack(), new Infantry());
            _unitShot = new Unit(new ShotAttack(), new Infantry());
            /*var _enemyMagicFly = new Enemy(new MagicalAttack(), new Fly());
            var _enemyFly = new Enemy(new ShotAttack(), new Fly());
            var _enemyJump = new Enemy(new ShotAttack(), new Jump());*/
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var mousePos = Input.mousePosition;
                mousePos.z = 10.0f;
                var position = _camera.ScreenToWorldPoint(mousePos);
                
                _unitMagic.Attack(position);
            }
            if (Input.GetMouseButtonDown(1))
            {
                var mousePos = Input.mousePosition;
                mousePos.z = 40.0f;
                var position = _camera.ScreenToWorldPoint(mousePos);
                
                _unitShot.Attack(position);
            }
        }
    }
}