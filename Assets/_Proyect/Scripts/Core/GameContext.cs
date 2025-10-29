using UnityEngine; 

namespace CubeFlux.Core
{
    /// Contiene los “singletons” lógicos del juego (StateMachine, etc).
    /// Vive desde Bootstrap y persiste entre escenas.
    public class GameContext : MonoBehaviour
    {
        public State.GameStateMachine StateMachine { get; private set; }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            // Registrarse a sí mismo para que otros puedan encontrarlo fácilmente.
            ServiceLocator.Register(this);

            // Registrar servicios (stubs por ahora)
            if (!ServiceLocator.TryGet<Services.IAudioService>(out _))
                ServiceLocator.Register<Services.IAudioService>(new Services.UnityAudioService());

            if (!ServiceLocator.TryGet<Services.IFxService>(out _))
                ServiceLocator.Register<Services.IFxService>(new Services.NullFxService());

            // Crear StateMachine
            StateMachine = new State.GameStateMachine();
            ServiceLocator.Register(StateMachine); // opcional: registro también de la SM
        }
    }
}
