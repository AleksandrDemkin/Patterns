using System;
using Code.Interfaces.Observer;
using UnityEngine;

namespace Code.View
{
    public class Enemy : MonoBehaviour, IHit
    {
        public event Action<float> OnHitChange = delegate(float f) { };

        public void Hit(float damage)
        {
            OnHitChange.Invoke(damage);
        }
    }
}