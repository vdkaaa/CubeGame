using UnityEngine;
using CubeFlux.Core;

public class PauseButtons : MonoBehaviour
{
    public void Pause()  => EventBus.Publish(new PauseRequested());
    public void Resume() => EventBus.Publish(new ResumeRequested());
    public void QuitToMenu() => EventBus.Publish(new ReturnToMenuRequested());
}
