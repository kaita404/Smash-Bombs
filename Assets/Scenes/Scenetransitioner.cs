using UnityEngine;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public float delay = 4f;
    public string sceneName;

    void Start()
    {
        StartCoroutine(LoadSceneAfterDelay(delay));
    }

    IEnumerator LoadSceneAfterDelay(float waitbySecs)
    {
        yield return new WaitForSeconds(waitbySecs);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}

