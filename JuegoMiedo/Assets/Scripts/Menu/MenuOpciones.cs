using Runemark.SCEMA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOpciones : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button mainMenuButton;


    [Header("Locations")]
    [SerializeField] private Location toMainMenuLocation;


    private void Start()
    {
        mainMenuButton.onClick.AddListener(OnMenuButtonPressed);
   }

    private void OnDisable()
    {
        mainMenuButton.onClick.RemoveListener(OnMenuButtonPressed);
    
    }

    public void OnMenuButtonPressed()
    {
        toMainMenuLocation.Enter();
    }



    
}
