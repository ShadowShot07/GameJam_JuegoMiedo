using Runemark.SCEMA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuInGame : MonoBehaviour
{
    [SerializeField] private bool isPaused = false;
    [Header("Settings Menu")]
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button closeSettings;

    [SerializeField] private Location toMainMenuLocation;
    
    [SerializeField] private Canvas settingsPanel;



    private void Start()
    {
        settingsPanel.enabled = false;

    }
    
    private void Update()
    {
        OpenMenu();

    }

    private void OnDisable()
    {
        closeSettings.onClick.RemoveListener(BackToGame);
        mainMenuButton.onClick.RemoveListener(BackToMainMenu);
    }

    
    //Pause game
    private void OpenMenu()
    {
        if (Input.GetKeyDown("escape"))
        {
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
        settingsPanel.enabled = true;

        //Pause game
        Time.timeScale = 0;
        isPaused = true;

        //Enable buttons
        closeSettings.onClick.AddListener(BackToGame);
        mainMenuButton.onClick.AddListener(BackToMainMenu);
    }
    public void BackToGame()
    {
        GameGlobal.instance.inGameMenuOff.Invoke();
        //Close settings panel
        settingsPanel.enabled = false;

        //Play game
        Time.timeScale = 1;
        isPaused = false;
    }
    public void BackToMainMenu()
    {
        settingsPanel.enabled = false;
        Time.timeScale = 1;
        toMainMenuLocation.Enter();
    }

}
