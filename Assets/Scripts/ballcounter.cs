using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballcounter : MonoBehaviour
{
    public int countCollisions = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
            countCollisions++;
    }
}
