using System;
using TMPro;
using UnityEngine;

namespace Asteroids.Interpreter
{
    internal sealed class Interpreter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private TMP_InputField _inputField;
        private void Start()
        {
            _inputField.onValueChanged.AddListener(Interpret);
        }
        
        private void Interpret(string value)
        {
            if (Int64.TryParse(value, out var number))
            {
                _text.text = ToDisplay(number);
            }
        }
        
        private string ToDisplay(long number)
        {
            if ((number < 0) || (number > 5000000)) throw new
                ArgumentOutOfRangeException(nameof(number),
                    "insert value betwheen 1 and 5000000");
            if (number < 1) return string.Empty;
            if (number >= 2000000) return "2M" + ToDisplay(number - 2000000);
            if (number >= 30000) return "30K" + ToDisplay(number - 30000);
            if (number >= 5000) return "5K" + ToDisplay(number - 5000);
            if (number >= 2000) return "2K" + ToDisplay(number - 2000);
            if (number >= 1000) return "1K" + ToDisplay(number - 1000);
            if (number >= 900) return "9CM" + ToDisplay(number - 900);
            if (number >= 500) return "5D" + ToDisplay(number - 500);
            if (number >= 400) return "4CD" + ToDisplay(number - 400);
            if (number >= 100) return "1C" + ToDisplay(number - 100);
            if (number >= 90) return "9XC" + ToDisplay(number - 90);
            if (number >= 50) return "5L" + ToDisplay(number - 50);
            if (number >= 40) return "4XL" + ToDisplay(number - 40);
            if (number >= 10) return "1X" + ToDisplay(number - 10);
            if (number >= 9) return "9IX" + ToDisplay(number - 9);
            if (number >= 5) return "5V" + ToDisplay(number - 5);
            if (number >= 4) return "4IV" + ToDisplay(number - 4);
            if (number >= 1) return "1I" + ToDisplay(number - 1);
            throw new ArgumentOutOfRangeException(nameof(number));
        }
    }
}