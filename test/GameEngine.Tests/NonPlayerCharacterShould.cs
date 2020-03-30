using Xunit;

namespace GameEngine.Tests
{
    public class NonPlayerCharacterShould
    {
        private readonly NonPlayerCharacter _sut;

        public NonPlayerCharacterShould()
        {
            _sut = new NonPlayerCharacter();
        }

        [Theory]
        [HealthDamageData]
        public void TakeDamage(int damage, int expectedDamage)
        {
            //Act
            _sut.TakeDamage(damage);
            //Assert
            Assert.Equal(expectedDamage, _sut.Health);
        }
    }
}