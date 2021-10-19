﻿using Asteroids.Chain_of_Responsibility;
using UnityEngine;

namespace Asteroids
{
    internal sealed class EnemyStarter : MonoBehaviour
    {

        private void Start()
        {
            var asteroid = new Enemy("Asteroid", 1, 1);
            
            var root = new EnemyModifier(asteroid);
            root.Add(new AddAttackModifier(asteroid, 5));
            root.Add(new AddAttackModifier(asteroid, 10));
            root.Add(new AddDefenseModifier(asteroid, 100));
            root.Handle();
        }
    }
}