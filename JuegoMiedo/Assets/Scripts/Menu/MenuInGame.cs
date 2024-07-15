using Runemark.SCEMA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuInGame : MonoBehaviour
{
    [SerializeField] private RoomManagerScriptableObject roomManagerScriptableObject;
    [SerializeField] private bool isPaused = false;
    [Header("Settings Menu")]
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button closeSettings;
    [SerializeField] private Slider mouseSensvtySlider;

    [SerializeField] private GameObject _playerUI;
    [SerializeField] private Location toMainMenuLocation;
    [SerializeField] private GameObject settingsPanel;

    [SerializeField] private bool inGameMenuIsDisable = false;
    private void Start()
    {
        settingsPanel.SetActive(false);
        mouseSensvtySlider.onValueChanged.AddListener(OnSensitivityChange);
        GameGlobal.instance.disablePlayer.AddListener(DisableInGameMenu);
    }
    
    private void Update()
    {
        if(!inGameMenuIsDisable)
        {
            OpenMenu();
        }
    }

    private void OnDisable()
    {
        closeSettings.onClick.RemoveListener(BackToGame);
        mainMenuButton.onClick.RemoveListener(BackToMainMenu);
        GameGlobal.instance.disablePlayer.RemoveListener(DisableInGameMenu);
    }

    private void OnSensitivityChange(float sensitivityValue)
    {
        GameGlobal.instance.globalSensitivity = sensitivityValue;
    }
    //Pause game
    private void OpenMenu()
    {
        if (Input.GetKeyDown("escape"))
        {
            AudioManager.instance.PlayUIAccept();
            if (isPaused)
            {
                BackToGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    //Settings button
    public void PauseGame()
    {
        GameGlobal.instance.inGameMenuOn.Invoke();
        //Show settings panel
        settingsPanel.SetActive(true);

        //Pause game
        isPaused = true;

        _playerUI.SetActive(false);

        //Enable buttons
        mouseSensvtySlider.value = GameGlobal.instance.globalSensitivity;
        closeSettings.onClick.AddListener(BackToGame);
        mainMenuButton.onClick.AddListener(BackToMainMenu);
    }
    public void BackToGame()
    {
        AudioManager.instance.PlayUICancel();
        GameGlobal.instance.inGameMenuOff.Invoke();
        //Close settings panel
        settingsPanel.SetActive(false);

        //Play game
        isPaused = false;

        _playerUI.SetActive(true);

        //Disable buttons
        closeSettings.onClick.RemoveListener(BackToGame);
        mainMenuButton.onClick.RemoveListener(BackToMainMenu);
    }

    public void DisableInGameMenu()
    {
        inGameMenuIsDisable = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void BackToMainMenu()
    {
        AudioManager.instance.PlayUICancel();
        settingsPanel.SetActive(false);
        roomManagerScriptableObject.currentRoom = 0;
        toMainMenuLocation.Enter();
    }
}
