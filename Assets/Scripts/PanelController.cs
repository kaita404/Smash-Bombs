using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PanelController : MonoBehaviour
{
    public GameObject infoPanel;

    void Start()
    {
        InitializeGame();
    }

    void InitializeGame()
    {
        Time.timeScale = 0f; // Pause the game at the beginning
        infoPanel.SetActive(true); // Show the information panel
    }

    void StartGame()
    {
        infoPanel.SetActive(false); // Hide the information panel
        Time.timeScale = 1f; // Resume the game
        Debug.Log("Game started!");
    }

    public void OnHidePanelButtonPressed()
    {
        StartGame(); // Start the game when the hide panel button is pressed
    }
}
