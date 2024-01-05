using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaniteBombs : MonoBehaviour
{

    // Update is called once per frame
    public void SpawnBomb(Object gameobj)
    {
        if(gameobj != null)
        {
            Instantiate(gameobj);
        }
    }
}
