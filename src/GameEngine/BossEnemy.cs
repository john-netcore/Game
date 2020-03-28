namespace GameEngine
{
    public class BossEnemy : Enemy
    {
        public override double TotalSpecialPower => 1000D;

        public override double SpecialPowerUses => 6D;
    }
}