namespace Asteroids.Chain_of_Responsibility
{
    internal sealed class AddDefenseModifierShip : ShipModifier
    {
        private readonly int _maxDefense;
        public AddDefenseModifierShip(Ship ship, int maxDefense)
            : base(ship)
        {
            _maxDefense = maxDefense;
        }

        public override void Handle1()
        {
            if (_ship.Defense <= _maxDefense)
            {
                _ship.Defense++;
            }

            base.Handle1();
        }
    }
}