namespace GameEngine
{
    public class NormalEnemy : Enemy
    {
        public override double TotalSpecialPower => 100D;

        public override double SpecialPowerUses => 2D;
    }
}