namespace CubeFlux.Core.State
{
    public enum GameStateKind { Menu, Playing, Paused, GameOver }

    public interface IGameState
    {
        GameStateKind Kind { get; }
        void Enter();
        void Exit();
    }
}
