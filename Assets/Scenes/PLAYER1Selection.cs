using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PLAYER1Selection : MonoBehaviour
{
    public void LoadScene()
    {
        // Load the new scene without destroying the current scene
        SceneManager.LoadScene("PLAYER 1 selection", LoadSceneMode.Single);
    }
}
