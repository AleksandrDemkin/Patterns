namespace Asteroids.Chain_of_Responsibility
{
    public sealed class AddAttackModifierShip : ShipModifier
    {
        private readonly int _attack1;
        
        public AddAttackModifierShip(Ship ship, int attack1)
            : base(ship)
        {
            _attack1 = attack1;
        }
        
        public override void Handle1()
        {
            _ship.Attack += _attack1;
            base.Handle1();
        }
    }
}