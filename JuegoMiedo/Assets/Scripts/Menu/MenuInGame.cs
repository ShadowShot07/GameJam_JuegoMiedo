using Runemark.SCEMA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuInGame : MonoBehaviour
{
    [Header("Settings Menu")]
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button closeSettings;

    [SerializeField] private Location toMainMenuLocation;
    
    [SerializeField] private Canvas settingsPanel;



    private void Start()
    {
        settingsPanel.enabled = false;
        
        mainMenuButton.onClick.AddListener(OnBackToMainMenuButtonPressed);
        settingsButton.onClick.AddListener(OnSettingsButtonPressed);
        
    }
    
    private void OnDisable()
    {
        mainMenuButton.onClick.RemoveListener(OnBackToMainMenuButtonPressed);
        settingsButton.onClick.RemoveListener(OnSettingsButtonPressed);
    }

    

    //Settings button
    public void OnSettingsButtonPressed()
    {
        settingsPanel.enabled = true;
        closeSettings.onClick.AddListener(OnCloseSettingsButtonPressed);
        closeSettings.onClick.AddListener(OnCloseSettingsButtonPressed);
    }
    public void OnCloseSettingsButtonPressed()
    {
        settingsPanel.enabled = false;
    }
    public void OnBackToMainMenuButtonPressed()
    {
        settingsPanel.enabled = false;
        toMainMenuLocation.Enter();
    }

}
