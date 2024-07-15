using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AnomalyDiscoveredUIController : MonoBehaviour
{
    [SerializeField] private AnomalyCollectionData anomalyDiscoveredData;
    [SerializeField] private TMP_Text anomalyDiscoverednumber;
    [SerializeField] private GameObject anomalyDiscoveredPanel;
    [SerializeField] private Button resetCollectionButton;

    private void Start()
    {
        Refresh();    
    }

    private void OnEnable()
    {
        resetCollectionButton.onClick.AddListener(OnResetCollectionPressed);
    }

    private void OnDisable()
    {
        resetCollectionButton.onClick.RemoveListener(OnResetCollectionPressed);
    }

    private void Refresh()
    {
        if (PlayerPrefsExtra.GetList<int>("AnomalyIndexDiscovered").Count >= 1)
        {
            anomalyDiscoveredData.SetAnomaliesDiscovered(PlayerPrefsExtra.GetList<int>("AnomalyIndexDiscovered"));
            anomalyDiscoveredPanel.SetActive(true);
            anomalyDiscoverednumber.text = (anomalyDiscoveredData.GetAnomaliesDiscovered() + " / 10").ToString();
        }
        else
        {
            anomalyDiscoveredPanel.SetActive(false);
        }
    }

    private void OnAnomalyCleaned() 
    {
        Refresh();
    }

    private void OnResetCollectionPressed()
    {
        PlayerPrefsExtra.SetList<int>("AnomalyIndexDiscovered", null);
        Refresh();
    }

}
