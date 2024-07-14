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

    [SerializeField] private Slider mouseSensvtySlider;

    [SerializeField] private Canvas settingsPanel;
    [SerializeField] private Canvas creditsPanel;



    private void Start()
    {
        settingsPanel.enabled = false;
        creditsPanel.enabled = false;

        mouseSensvtySlider.onValueChanged.AddListener(OnSensitivityChange);

        startButton.onClick.AddListener(OnStartButtonPressed);
        SettingsButton.onClick.AddListener(OnSettingsButtonPressed);
        CreditsButton.onClick.AddListener(OnCreditsButtonPressed);

        AudioManager.instance.StartMusic();
    }
    //Play button
    private void OnDisable()
    {
        startButton.onClick.RemoveListener(OnStartButtonPressed);
        SettingsButton.onClick.RemoveListener(OnSettingsButtonPressed);
    }

    public void OnStartButtonPressed()
    {
        AudioManager.instance.PlayUIAccept();
        toGameLocation.Enter();
        AudioManager.instance.StopMusic();
    }

    //Settings button
    public void OnSettingsButtonPressed()
    {
        AudioManager.instance.PlayUIAccept();
        settingsPanel.enabled = true;
        mouseSensvtySlider.value = GameGlobal.instance.globalSensitivity;
        closeSettings.onClick.AddListener(OnCloseSettingsButtonPressed);
    }
    public void OnCloseSettingsButtonPressed()
    {
        AudioManager.instance.PlayUICancel();
        settingsPanel.enabled = false;
    }

    private void OnSensitivityChange(float sensitivityValue)
    {
        GameGlobal.instance.globalSensitivity = sensitivityValue;
    }

    //Credits button
    public void OnCreditsButtonPressed()
    {
        AudioManager.instance.PlayUIAccept();
        creditsPanel.enabled = true;
        closeCredits.onClick.AddListener(OnCloseCreditsButtonPressed);
    }
    public void OnCloseCreditsButtonPressed()
    {
        AudioManager.instance.PlayUICancel();
        creditsPanel.enabled = false;
    }
}
