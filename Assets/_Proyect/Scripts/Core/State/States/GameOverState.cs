using UnityEngine.SceneManagement;

namespace CubeFlux.Core.State.States
{
    public class GameOverState : IGameState
    {
        private readonly GameStateMachine _sm;
        public GameOverState(GameStateMachine sm) { _sm = sm; }
        public GameStateKind Kind => GameStateKind.GameOver;

        public void Enter() => SceneManager.LoadScene("Results", LoadSceneMode.Single);
        public void Exit() { }
    }
}
