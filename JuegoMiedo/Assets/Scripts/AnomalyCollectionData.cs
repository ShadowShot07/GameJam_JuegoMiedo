using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AnomalyDiscoveredData")]
public class AnomalyCollectionData : ScriptableObject
{
    [SerializeField] private int anomaliesDiscovered;
    [SerializeField] private int totalAnomalies;

    public void AddAnomalyDiscovered()
    {
        anomaliesDiscovered++;
    }

    public int GetAnomaliesDiscovered()
    {
        return anomaliesDiscovered;
    }

    public int GetTotalAnomalies()
    {
        return totalAnomalies;
    }
}
