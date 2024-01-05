using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randombombinstanite : MonoBehaviour
{
    public GameObject bombdropper;

    // Update is called once per frame
    void Update()
    {
        
        StartCoroutine(Balldrops());
    }

    private IEnumerator Balldrops()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(16, 0), 5, Random.Range(16, 0));
        Instantiate(bombdropper, randomSpawnPosition, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
    }

}
