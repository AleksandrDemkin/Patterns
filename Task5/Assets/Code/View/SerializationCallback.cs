using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

namespace Asteroids.SerializationCallback
{
    public class SerializationCallback : MonoBehaviour
    {
        [Serializable]
        public class AsteroidRecord
        {
            public Sprite img;
            public int value;
        };
        
        public List<int> _keys = new List<int> { 1, 2, 3 };
        public List<AsteroidRecord> _values = new List<AsteroidRecord> {};

        public Dictionary<int, AsteroidRecord>  _myDictionary = new Dictionary<int, AsteroidRecord>();

        public void OnBeforeSerialize()
        {
            _keys.Clear();
            _values.Clear();

            foreach (var kvp in _myDictionary)
            {
                _keys.Add(kvp.Key);
                _values.Add(kvp.Value);
            }
        }

        public void OnAfterDeserialize()
        {
            _myDictionary = new Dictionary<int, AsteroidRecord>();

            for (int i = 0; i != Math.Min(_keys.Count, _values.Count); i++)
                _myDictionary.Add(_keys[i], _values[i]);
        }

        void OnGUI()
        {
            foreach (var kvp in _myDictionary)
                GUILayout.Label("Key: " + kvp.Key + " value: " + kvp.Value);
        }
    }
}
