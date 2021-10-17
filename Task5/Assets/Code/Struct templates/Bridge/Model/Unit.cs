using Code.Struct_templates.Bridge.Interfaces;
using UnityEngine;

namespace Code.Struct_templates.Bridge.Model
{
    internal sealed class Unit
    	{
	        private readonly IAttack _attack;
    		private readonly IMove _move;
    		
    		public Unit(IAttack attack, IMove move)
    		{
    			_attack = attack;
    			_move = move;
    		}
    		public void Attack(Vector3 position)
    		{
	            _attack.Attack(position);
    		}
    		public void Move()
    		{
    			_move.Move();
    		}
    	}
}