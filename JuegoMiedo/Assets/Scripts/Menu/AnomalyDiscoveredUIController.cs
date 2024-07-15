using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnomalyDiscoveredUIController : MonoBehaviour
{
    [SerializeField] private AnomalyCollectionData anomalyDiscoveredData;
    [SerializeField] private TMP_Text anomalyDiscoverednumber;
    [SerializeField] private GameObject anomalyDiscoveredPanel;

    private void Start()
    {
        if (PlayerPrefsExtra.GetList<int>("AnomalyIndexDiscovered").Count >=1)
        {
            anomalyDiscoveredData.SetAnomaliesDiscovered(PlayerPrefsExtra.GetList<int>("AnomalyIndexDiscovered"));
            anomalyDiscoveredPanel.SetActive(true);
            Refresh();
        }
        else 
        {
            anomalyDiscoveredPanel.SetActive(false);
        }
        
    }

    private void Refresh()
    {
        anomalyDiscoverednumber.text = (anomalyDiscoveredData.GetAnomaliesDiscovered() + " / 10").ToString();
    }

    private void OnAnomalyCleaned() 
    {
        Refresh();
    }

}
