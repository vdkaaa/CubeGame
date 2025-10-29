using UnityEngine;

namespace CubeFlux.Core.Services
{
    public class UnityAudioService : IAudioService
    {
        public float MasterVolume { get; set; } = 1f;
        public float MusicVolume { get; set; } = 0.7f;
        public float SfxVolume   { get; set; } = 1f;

        public void PlaySfx(string id, float vol = 1f)
        {
            // TODO Día 4–6: usar AudioMixer/Addressables.
            Debug.Log($"[Audio] SFX {id} vol={vol * SfxVolume * MasterVolume:0.00}");
        }

        public void PlayMusic(string id, float vol = 1f, bool loop = true)
        {
            Debug.Log($"[Audio] MUSIC {id} vol={vol * MusicVolume * MasterVolume:0.00} loop={loop}");
        }

        public void StopMusic(float fadeOut = 0f)
        {
            Debug.Log($"[Audio] MUSIC STOP fadeOut={fadeOut:0.00}");
        }
    }
}
