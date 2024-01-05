using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main1 : MonoBehaviour
{
    public void LoadScene()
    {
        // Load the new scene without destroying the current scene
        SceneManager.LoadScene("main1", LoadSceneMode.Single);
    }
}
