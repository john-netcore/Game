using Xunit;

namespace GameEngine.Tests
{
    public class BossEnemyShould
    {

        private BossEnemy _sut;

        public BossEnemyShould()
        {
            _sut = new BossEnemy();
        }

        /*********************** Assertions against floating points ****************************/

        [Fact]
        [Trait("Category", "Boss")]
        public void HaveCorrectPower()
        {
            //Arrange
            double expected = 166.667;
            //Act
            double actual = _sut.TotalSpecialAttackPower;
            //Assert
            Assert.Equal(expected, actual, precision: 3);
        }
    }
}