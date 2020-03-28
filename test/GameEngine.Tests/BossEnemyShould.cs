using Xunit;

namespace GameEngine.Tests
{
    public class BossEnemyShould
    {

        /*********************** Assertions against floating points ****************************/

        [Fact]
        public void HaveCorrectPower()
        {
            //Arrange
            BossEnemy sut = new BossEnemy();
            double expected = 166.667;
            //Act
            double actual = sut.TotalSpecialAttackPower;
            //Assert
            Assert.Equal(expected, actual, precision: 3);
        }
    }
}