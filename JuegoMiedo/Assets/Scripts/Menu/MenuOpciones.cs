using Runemark.SCEMA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOpciones : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button startButton;
    [SerializeField] private Button SettingsButton;
    [SerializeField] private Button ExitButton;
    [SerializeField] private Button CreditsButton;

    [Header("Locations")]
    [SerializeField] private Location toGameLocation;
    [SerializeField] private Location toSettingsLocation;
    [SerializeField] private Location toCreditsLocation;

    private void Start()
    {
        startButton.onClick.AddListener(OnStartButtonPressed);
        SettingsButton.onClick.AddListener(OnSettingsButtonPressed);
    }

    private void OnDisable()
    {
        startButton.onClick.RemoveListener(OnStartButtonPressed);
        SettingsButton.onClick.RemoveListener(OnSettingsButtonPressed);
    }

    public void OnStartButtonPressed()
    {
        toGameLocation.Enter();
    }

    public void OnSettingsButtonPressed()
    {
        toSettingsLocation.Enter();
    }

    
}
