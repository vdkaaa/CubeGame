using UnityEngine.SceneManagement;

namespace CubeFlux.Core.State.States
{
    public class MenuState : IGameState
    {
        private readonly GameStateMachine _sm;
        public MenuState(GameStateMachine sm) { _sm = sm; }
        public GameStateKind Kind => GameStateKind.Menu;

        public void Enter() => SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        public void Exit() { }
    }
}
