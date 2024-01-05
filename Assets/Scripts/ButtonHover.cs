using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour
{
    public Image hoverImage;

    void Start()
    {
        hoverImage.gameObject.SetActive(false);
    }

    public void OnPointerEnter()
    {
        hoverImage.gameObject.SetActive(true);
    }

    public void OnPointerExit()
    {
        hoverImage.gameObject.SetActive(false);
    }
}