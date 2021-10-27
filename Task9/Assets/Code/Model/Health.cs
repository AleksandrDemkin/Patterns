﻿namespace Code.Model
{
    internal sealed class Health
    {
        public float Max { get; }
        public float Current { get; internal set; }

        public Health(float max, float current)
        {
            Max = max;
            Current = current;
        }

        public void ChangeCurrentHealth(float hp)
        {
            Current = hp;
        }
    }
}