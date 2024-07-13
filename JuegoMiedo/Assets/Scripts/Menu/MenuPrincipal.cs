using Runemark.SCEMA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    [Header("Main Menu")]
    
    [SerializeField] private Button startButton;
    [SerializeField] private Button SettingsButton;
    [SerializeField] private Button ExitButton;
    [SerializeField] private Button CreditsButton;

    [SerializeField] private Location toGameLocation;

    [Header("SubMenus")]
    [SerializeField] private Button closeSettings;
    [SerializeField] private Button closeCredits;

    [SerializeField] private Canvas settingsPanel;
    [SerializeField] private Canvas creditsPanel;



    private void Start()
    {
        settingsPanel.enabled = false;
        creditsPanel.enabled = false;
        startButton.onClick.AddListener(OnStartButtonPressed);
        SettingsButton.onClick.AddListener(OnSettingsButtonPressed);
        CreditsButton.onClick.AddListener(OnCreditsButtonPressed);
    }
    //Play button
    private void OnDisable()
    {
        startButton.onClick.RemoveListener(OnStartButtonPressed);
        SettingsButton.onClick.RemoveListener(OnSettingsButtonPressed);
    }

    public void OnStartButtonPressed()
    {
        toGameLocation.Enter();
    }

    //Settings button
    public void OnSettingsButtonPressed()
    {
        settingsPanel.enabled = true;
        closeSettings.onClick.AddListener(OnCloseSettingsButtonPressed);
    }
    public void OnCloseSettingsButtonPressed()
    {
        settingsPanel.enabled = false;
    }

    //Credits button
    public void OnCreditsButtonPressed()
    {
        creditsPanel.enabled = true;
        closeCredits.onClick.AddListener(OnCloseCreditsButtonPressed);
    }
    public void OnCloseCreditsButtonPressed()
    {
        creditsPanel.enabled = false;
    }
}
