using System;
using Xunit;

namespace GameEngine.Tests
{
    [Trait("Category", "Enemy")]
    public class EnemyFactoryShould : IDisposable
    {

        private EnemyFactory _sut;

        public EnemyFactoryShould()
        {
            _sut = new EnemyFactory();
        }

        /*********************** Assertions against Object Types ****************************/

        [Fact]
        public void CreateNormalEnemyByDefault()
        {
            //Act
            Enemy actual = _sut.Create("Zombie");
            //Assert
            Assert.IsType<NormalEnemy>(actual);
        }

        [Fact]
        public void NotCreateNormalEnemy()
        {
            //Act
            Enemy actual = _sut.Create("Zombie King", isBoss: true);
            //Assert
            Assert.IsNotType<NormalEnemy>(actual);
        }

        [Fact]
        public void BeDerivedFromEnemyType()
        {
            //Act
            Enemy actual = _sut.Create("Zombie King", isBoss: true);
            //Assert
            Assert.IsAssignableFrom<Enemy>(actual);
        }

        /*********************** Assertions against Object Instances ****************************/

        [Fact]
        public void CreateSeparateInstances()
        {
            //Act
            Enemy enemy1 = _sut.Create("Zombie");
            Enemy enemy2 = _sut.Create("Zombie");
            //Assert
            Assert.NotSame(enemy1, enemy2);
        }

        /*********************** Assertions Handling with Exceptions ****************************/

        [Fact]
        public void NotAllowNullName()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() => _sut.Create(null));
        }

        [Fact]
        public void NotAllowNullNameWithNameParamAsErrorMessage()
        {
            //Assert
            Assert.Throws<ArgumentNullException>("name", () => _sut.Create(null));
        }

        [Fact]
        public void OnlyAllowQueenOrKingAsBossEnemy()
        {
            //Assert
            var ex = Assert.Throws<EnemyCreationException>(() => _sut.Create("Zombie", isBoss: true));
            Assert.Equal("Zombie", ex.RequestedEnemyName);
        }

        public void Dispose()
        {
            //Clean up code.
        }
    }
}