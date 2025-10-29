using UnityEngine;
using UnityEngine.SceneManagement;

namespace CubeFlux.Core
{
    /// Vive en Bootstrap.unity. Prepara “servicios” y salta a Menu.
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private bool _loadMenuOnStart = true;
        [SerializeField] private int _menuSceneBuildIndex = 1; // Build Settings: 0=Bootstrap, 1=Menu

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            // Ejemplo: registra servicios reales en Días 2–3
            // ServiceLocator.Register<IAudioService>(new UnityAudioService());
            // ServiceLocator.Register<IFxService>(new FxService());

            Application.targetFrameRate = 60;
            QualitySettings.vSyncCount = 0;

#if UNITY_ANDROID
            Screen.orientation = ScreenOrientation.Portrait;
#endif
        }

        private void Start()
        {
            if (_loadMenuOnStart)
            {
                SceneManager.LoadScene(_menuSceneBuildIndex, LoadSceneMode.Single);
            }
        }
    }
}
