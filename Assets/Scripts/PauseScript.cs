using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0f;
        Debug.Log("Game Paused");
    }
}