// _Project/Scripts/UI/MenuPlayButton.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPlayButton : MonoBehaviour
{
    public void Play() => SceneManager.LoadScene("Game");
}
