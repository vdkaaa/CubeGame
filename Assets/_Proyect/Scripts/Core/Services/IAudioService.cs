namespace CubeFlux.Core.Services
{
    public interface IAudioService
    {
        void PlaySfx(string id, float vol = 1f);
        void PlayMusic(string id, float vol = 1f, bool loop = true);
        void StopMusic(float fadeOut = 0f);
        float MasterVolume { get; set; }
        float MusicVolume { get; set; }
        float SfxVolume { get; set; }
    }
}
