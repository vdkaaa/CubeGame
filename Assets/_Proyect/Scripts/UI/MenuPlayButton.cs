using UnityEngine;
using CubeFlux.Core;

public class MenuPlayButton : MonoBehaviour
{
    public void Play() => EventBus.Publish(new PlayRequested());
}
