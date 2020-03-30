

using Xunit;

namespace GameEngine.Tests
{
    [CollectionDefinition("GameState collection")]
    public class GameStateCollection : ICollectionFixture<GameStateFixture>
    {
        // Use the attribute [Collection("GameState collection")] i the test classes you want to share the GameStateFixture instance.
    }
}