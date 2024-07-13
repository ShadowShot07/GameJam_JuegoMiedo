using Runemark.SCEMA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
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
    }

    private void OnDisable()
    {
        startButton.onClick.RemoveListener(OnStartButtonPressed);
    }

    public void OnStartButtonPressed()
    {
        toGameLocation.Enter();
    }
}
