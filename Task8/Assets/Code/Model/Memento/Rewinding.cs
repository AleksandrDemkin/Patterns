using UnityEngine;
namespace Memento
{
    public sealed class Rewinding
    {
        private TimeBody _timeBody;

        internal void Rewind ()
        {
            if (_timeBody._pointsInTime.Count > 1)
            {
                PointInTime pointInTime = _timeBody._pointsInTime[0];
                _timeBody.transform.position = pointInTime.Position;
                _timeBody.transform.rotation = pointInTime.Rotation;
                _timeBody._pointsInTime.RemoveAt(0);
            }
            else
            {
                PointInTime pointInTime = _timeBody._pointsInTime[0];
                _timeBody.transform.position = pointInTime.Position;
                _timeBody.transform.rotation = pointInTime.Rotation;
                StopRewind();
            }
        }

        internal void Record ()
        {
            if (_timeBody._pointsInTime.Count > Mathf.Round(_timeBody._recordTime /
                                                            Time.fixedDeltaTime))
            {
                _timeBody._pointsInTime.RemoveAt(_timeBody._pointsInTime.Count - 1);
            }

            _timeBody._pointsInTime.Insert(0, new PointInTime(_timeBody.transform.position, _timeBody.transform.rotation, _timeBody._rb.velocity, _timeBody._rb.angularVelocity));
        }

        internal void StartRewind ()
        {
            _timeBody._isRewinding = true;
            _timeBody._rb.isKinematic = true;
        }

        internal void StopRewind ()
        {
            _timeBody._isRewinding = false;
            _timeBody._rb.isKinematic = false;
            _timeBody._rb.velocity = _timeBody._pointsInTime[0].Velocity;
            _timeBody._rb.angularVelocity = _timeBody._pointsInTime[0].AngularVelocity;
        }
    }
}