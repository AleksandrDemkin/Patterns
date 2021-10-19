using System.Collections.Generic;
using UnityEngine;

namespace Memento
{
    public sealed class TimeBody : MonoBehaviour
    {
        [SerializeField] internal float _recordTime = 5f;
        internal List<PointInTime> _pointsInTime;
        internal Rigidbody _rb;
        internal bool _isRewinding;
        private readonly Rewinding _rewinding;

        private void Start ()
        {
            _pointsInTime = new List<PointInTime>();
            _rb = GetComponent<Rigidbody>();
        }
        
        private void Update ()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _rewinding.StartRewind();
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                _rewinding.StopRewind();
            }
        }
        
        private void FixedUpdate ()
        {
            if (_isRewinding)
            {
                _rewinding.Rewind();
            }
            else
            {
                _rewinding.Record();
            }
        }
    }
}