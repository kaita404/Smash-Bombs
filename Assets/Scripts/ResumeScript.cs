using UnityEngine;
using UnityEngine.UI;

public class ResumeScript : MonoBehaviour
{
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        Debug.Log("Game Resumed");
    }
}