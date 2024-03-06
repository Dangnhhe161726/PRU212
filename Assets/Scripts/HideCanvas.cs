using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCanvas : MonoBehaviour
{

    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject settings;

    public void Start()
    {
        settings.SetActive(false);
    }

    public void HideTheCanvas()
    {
        menu.SetActive(false); 
        settings.SetActive(true);
    }
}
