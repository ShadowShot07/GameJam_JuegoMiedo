using Runemark.SCEMA;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    [Header("Main Menu")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private Button startButton;
    [SerializeField] private Button SettingsButton;
    [SerializeField] private Button startExitMenu;
    [SerializeField] private GraphicRaycaster MenuEntero;

    [SerializeField] private Location toGameLocation;

    [Header("SubMenus")]
    [SerializeField] private Button closeSettings;
    [SerializeField] private Slider mouseSensvtySlider;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject exitPanel;

    [Header("Menu Exit")]
    [SerializeField] private Button enterbutton;
    [SerializeField] private Button exitButton;



    private void Start()
    {
        settingsPanel.SetActive(false);

        mouseSensvtySlider.onValueChanged.AddListener(OnSensitivityChange);
        startButton.onClick.AddListener(OnStartButtonPressed);
        SettingsButton.onClick.AddListener(OnSettingsButtonPressed);
        startExitMenu.onClick.AddListener(OnExitMenuButtonPressed);
        Cursor.lockState = CursorLockMode.None;

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
        settingsPanel.SetActive(true);
        mainMenu.SetActive(false);
        mouseSensvtySlider.value = GameGlobal.instance.globalSensitivity;
        closeSettings.onClick.AddListener(OnCloseSettingsButtonPressed);
    }
    public void OnCloseSettingsButtonPressed()
    {
        AudioManager.instance.PlayUICancel();
        settingsPanel.SetActive(false);
        mainMenu.SetActive(true);
    }

    private void OnSensitivityChange(float sensitivityValue)
    {
        GameGlobal.instance.globalSensitivity = sensitivityValue;
    }

    private void OnExitMenuButtonPressed()
    {
        exitPanel.SetActive(true);
        MenuEntero.enabled = false;
        enterbutton.onClick.AddListener(OnEnterButtonPressed);
        exitButton.onClick.AddListener(OnExitButtonPressed);
    }

    private void OnEnterButtonPressed()
    {
        exitPanel.SetActive(false);
        MenuEntero.enabled = true;
    }

    private void OnExitButtonPressed()
    {
        Application.Quit();
    }

    //Credits button
    public void OnCreditsButtonPressed()
    {
        AudioManager.instance.PlayUIAccept();
    }
    public void OnCloseCreditsButtonPressed()
    {
        AudioManager.instance.PlayUICancel();
    }
}
