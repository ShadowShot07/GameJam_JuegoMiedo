using Runemark.SCEMA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Location toGameLocation;

    private void Start()
    {
        startButton.onClick.AddListener(OnStartButtonPressed);
        AudioManager.instance.StartMusic();
    }

    private void OnDisable()
    {
        startButton.onClick.RemoveListener(OnStartButtonPressed);
    }

    public void OnStartButtonPressed()
    {
        toGameLocation.Enter();
        AudioManager.instance.StopMusic();
    }
}
