using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    //IClassFixture tells xUnit to create an instance of GameStateFixture before running the tests and call its Dispose method when all the tests have run.
    public class GameStateShould : IClassFixture<GameStateFixture>
    {

        private readonly GameStateFixture _gameStateFixture;

        //For writing test outputs (instead of Console.WriteLine).
        private readonly ITestOutputHelper _output;

        //IClassFixture will inject the same GameStateFixture instance for each test method.
        public GameStateShould(GameStateFixture gameStateFixture, ITestOutputHelper output)
        {
            _gameStateFixture = gameStateFixture;
            _output = output;
        }

        [Fact]
        public void DamageAllPlayersWhenEarthquake()
        {
            //Arrange
            var sut = _gameStateFixture.GameState;
            _output.WriteLine($"GameState ID: {sut.Id}");
            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();
            sut.Players.Add(player1);
            sut.Players.Add(player2);
            var expectedHealth = player1.Health - GameState.EarthquakeDamage;

            //Act
            sut.Earthquake();

            //Assert
            Assert.All(sut.Players, (player) => Assert.True(player.Health == expectedHealth));
        }

        [Fact]
        public void Reset()
        {
            //Arrange
            var sut = _gameStateFixture.GameState;
            _output.WriteLine($"GameState ID: {sut.Id}");
            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();
            sut.Players.Add(player1);
            sut.Players.Add(player2);

            //Act
            sut.Reset();

            //Assert
            Assert.Empty(sut.Players);
        }
    }
}