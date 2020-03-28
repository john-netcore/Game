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

        [Fact]
        public void NotCreateNormalEnemy()
        {
            //Arrange
            EnemyFactory sut = new EnemyFactory();
            //Act
            Enemy actual = sut.Create("Zombie King", isBoss: true);
            //Assert
            Assert.IsNotType<NormalEnemy>(actual);
        }

        [Fact]
        public void BeDerivedFromEnemyType()
        {
            //Arrange
            EnemyFactory sut = new EnemyFactory();
            //Act
            Enemy actual = sut.Create("Zombie King", isBoss: true);
            //Assert
            Assert.IsAssignableFrom<Enemy>(actual);
        }

        /*********************** Assertions against Object Instances ****************************/

        [Fact]
        public void CreateSeparateInstances()
        {
            //Arrange
            EnemyFactory sut = new EnemyFactory();
            //Act
            Enemy enemy1 = sut.Create("Zombie");
            Enemy enemy2 = sut.Create("Zombie");
            //Assert
            Assert.NotSame(enemy1, enemy2);
        }
    }
}