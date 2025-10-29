using UnityEngine;

namespace CubeFlux.Core.Services
{
    public class NullFxService : IFxService
    {
        public void HitFlash(Transform target, float strength = 1f) { /* no-op */ }
        public void Dissolve(Transform target, float duration = 0.5f) { /* no-op */ }
        public void ScreenFlash(float strength = 0.5f) { /* no-op */ }
    }
}
