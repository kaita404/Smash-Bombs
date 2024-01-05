using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class textontrigger : MonoBehaviour
{
    public GameObject myImage;

    private void OnTriggerEnter(Collider other)
    {
        //Text sets your text to say this message
        myImage.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        //Text sets your text to say this message
        myImage.SetActive(false);
    }
}
