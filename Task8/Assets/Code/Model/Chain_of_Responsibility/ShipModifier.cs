namespace Asteroids.Chain_of_Responsibility
{
    public class ShipModifier
    {
        protected Ship _ship;
        protected ShipModifier Next1;

        public ShipModifier(Ship ship)
        {
            _ship = ship;
        }
        
        public void Add(ShipModifier cm1)
        {
            if (Next1 != null)
            {
                Next1.Add(cm1);
            }
            else
            {
                Next1 = cm1;
            }
        }
                
        public virtual void Handle1() => Next1?.Handle1();
    }
}