using UnityEngine;

namespace CubeFlux.Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private GameObject _gameContextPrefab; // arrastra un prefab con GameContext
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            Application.targetFrameRate = 60;
            QualitySettings.vSyncCount = 0;

#if UNITY_ANDROID
            Screen.orientation = ScreenOrientation.Portrait;
#endif
            EnsureContext();
        }

        private void Start()
        {
            // Entrar a Menu a través de la StateMachine
            // Ahora obtenemos la StateMachine directamente del ServiceLocator. ¡Mucho más rápido y robusto!
            ServiceLocator.Get<State.GameStateMachine>().ChangeTo(State.GameStateKind.Menu);
        }

        private void EnsureContext()
        {
            // Comprobamos si el servicio ya está registrado.
            if (!ServiceLocator.TryGet<GameContext>(out _))
            {
                // Si no lo está, lo creamos. El propio GameContext se registrará en su Awake().
                if (_gameContextPrefab != null) Instantiate(_gameContextPrefab);
                else new GameObject("GameContext").AddComponent<GameContext>();
            }
        }
    }
}
