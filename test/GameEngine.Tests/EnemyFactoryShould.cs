using Xunit;

namespace GameEngine.Tests
{
    public class EnemyFactoryShould
    {

        /*********************** Assertions against Object Types ****************************/

        [Fact]
        public void CreateNormalEnemyByDefault()
        {
            //Arrange
            EnemyFactory sut = new EnemyFactory();
            //Act
            Enemy actual = sut.Create("Zombie");
            //Assert
            Assert.IsType<NormalEnemy>(actual);
        }
    }
}