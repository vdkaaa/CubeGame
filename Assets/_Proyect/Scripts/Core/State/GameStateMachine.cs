using System;
using System.Collections.Generic;
using UnityEngine;

namespace CubeFlux.Core.State
{
    public class GameStateMachine
    {
        public IGameState Current { get; private set; }
        private readonly Dictionary<GameStateKind, IGameState> _states = new();

        public GameStateMachine()
        {
            // Instancia y registra estados. Puedes inyectar dependencias aquí.
            Register(new States.MenuState(this));
            Register(new States.PlayingState(this));
            Register(new States.PausedState(this));
            Register(new States.GameOverState(this));

            // Suscribe a eventos globales:
            EventBus.Subscribe<PlayRequested>(_ => ChangeTo(GameStateKind.Playing));
            EventBus.Subscribe<PauseRequested>(_ => ChangeTo(GameStateKind.Paused));
            EventBus.Subscribe<ResumeRequested>(_ => ChangeTo(GameStateKind.Playing));
            EventBus.Subscribe<GameOverRequested>(_ => ChangeTo(GameStateKind.GameOver));
            EventBus.Subscribe<ReturnToMenuRequested>(_ => ChangeTo(GameStateKind.Menu));
        }

        private void Register(IGameState state) => _states[state.Kind] = state;

        public void ChangeTo(GameStateKind kind)
        {
            if (!_states.TryGetValue(kind, out var next))
            {
                Debug.LogError($"[SM] Estado no registrado: {kind}");
                return;
            }

            if (ReferenceEquals(Current, next)) return;

            Current?.Exit();
            Current = next;
            Debug.Log($"[SM] → {Current.Kind}");
            Current.Enter();
        }
    }
}
