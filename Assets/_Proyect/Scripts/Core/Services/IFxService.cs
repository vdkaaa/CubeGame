using UnityEngine;

namespace CubeFlux.Core.Services
{
    public interface IFxService
    {
        void HitFlash(Transform target, float strength = 1f);
        void Dissolve(Transform target, float duration = 0.5f);
        void ScreenFlash(float strength = 0.5f);
    }
}
