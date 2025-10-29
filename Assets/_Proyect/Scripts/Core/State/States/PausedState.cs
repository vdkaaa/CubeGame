using UnityEngine;

namespace CubeFlux.Core.State.States
{
    public class PausedState : IGameState
    {
        private readonly GameStateMachine _sm;
        private float _prevTimeScale;

        public PausedState(GameStateMachine sm) { _sm = sm; }
        public GameStateKind Kind => GameStateKind.Paused;

        public void Enter()
        {
            _prevTimeScale = Time.timeScale;
            Time.timeScale = 0f;
            // aquí puedes abrir UI de pausa vía un controlador de UI (día 3–4)
        }

        public void Exit() => Time.timeScale = _prevTimeScale;
    }
}
