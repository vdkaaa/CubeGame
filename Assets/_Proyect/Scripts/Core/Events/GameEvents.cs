namespace CubeFlux.Core
{
    // Eventos de alto nivel
    public readonly struct PlayRequested : IGameEvent { }
    public readonly struct PauseRequested : IGameEvent { }
    public readonly struct ResumeRequested : IGameEvent { }
    public readonly struct GameOverRequested : IGameEvent { }
    public readonly struct ReturnToMenuRequested : IGameEvent { }

    // Si quieres payloads:
    public readonly struct ScoreSubmitted : IGameEvent
    {
        public readonly int Score;
        public ScoreSubmitted(int score) { Score = score; }
    }
}
