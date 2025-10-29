using UnityEngine;
using CubeFlux.Core;

public class ResultsButtons : MonoBehaviour
{
    public void Retry() => EventBus.Publish(new PlayRequested());
    public void Menu()  => EventBus.Publish(new ReturnToMenuRequested());
}
