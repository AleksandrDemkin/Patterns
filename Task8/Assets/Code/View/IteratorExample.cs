using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Asteroids.Iterator
{
    internal sealed class IteratorExample : MonoBehaviour
    {
        private void Start()
        {
            var ability = new List<IAbility>
            {
                new Ability("Inner Fire", 100, Target.None, DamageType.Laser),
                new Ability("Burning", 200, Target.Unit | Target.Autocast,
                    DamageType.Laser),
                new Ability("Poisoning", 300, Target.Unit, DamageType.Poison),
                new Ability("Explosion", 500, Target.Passive,
                    DamageType.Bomb),
            };
            IEnemy enemy = new Enemy(ability);
            Debug.Log(enemy[0]);
            Debug.Log(new string('+', 50));
            Debug.Log(enemy[Target.Unit | Target.Autocast]);
            Debug.Log(new string('+', 50));
            Debug.Log(enemy[Target.Unit | Target.Passive]);
            Debug.Log(new string('+', 50));
            Debug.Log(enemy.MaxDamage);
            Debug.Log(new string('+', 50));
            foreach (var o in enemy)
            {
                Debug.Log(o);
            }
            
            Debug.Log(new string('+', 50));
            foreach (var o in enemy.GetAbility().Take(2))
            {
                Debug.Log(o);
            }
            
            Debug.Log(new string('+', 50));
            foreach (var o in enemy.GetAbility(DamageType.Laser))
            {
                Debug.Log(o);
            }
        }
    }
}