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
        [MemberData(nameof(InternalHealthDamageTestData.TestData), MemberType = typeof(InternalHealthDamageTestData))]
        public void TakeDamage(int damage, int expectedDamage)
        {
            //Act
            _sut.TakeDamage(damage);
            //Assert
            Assert.Equal(expectedDamage, _sut.Health);
        }
    }
}