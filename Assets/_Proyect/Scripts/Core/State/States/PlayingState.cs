using UnityEngine.SceneManagement;
using CubeFlux.Core.Services;

namespace CubeFlux.Core.State.States
{
    public class PlayingState : IGameState
    {
        private readonly GameStateMachine _sm;
        public PlayingState(GameStateMachine sm) { _sm = sm; }
        public GameStateKind Kind => GameStateKind.Playing;

        public void Enter()
        {
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
            if (ServiceLocator.TryGet<IAudioService>(out var audio))
                audio.PlayMusic("run", 0.8f, loop: true);
        }

        public void Exit()
        {
            if (ServiceLocator.TryGet<IAudioService>(out var audio))
                audio.StopMusic(0.2f);
        }
    }
}
