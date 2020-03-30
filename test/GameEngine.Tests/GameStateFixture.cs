using System;

namespace GameEngine.Tests
{
    public class GameStateFixture : IDisposable
    {
        public GameState GameState { get; private set; }

        public GameStateFixture()
        {
            GameState = new GameState();
        }

        public void Dispose()
        {
            //Clean up
        }
    }
}