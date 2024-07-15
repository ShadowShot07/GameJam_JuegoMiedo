using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AnomalyDiscoveredData")]
public class AnomalyCollectionData : ScriptableObject
{
    [SerializeField] private int totalAnomalies;
    [SerializeField] private List<int> anomaliesDiscovered;


    public void AddAnomalyDiscovered(int index)
    {
        anomaliesDiscovered.Add(index);
        PlayerPrefsExtra.SetList<int>("AnomalyIndexDiscovered", anomaliesDiscovered);
    }

    public int GetAnomaliesDiscovered()
    {
        return anomaliesDiscovered.Count;
    }

    public int GetTotalAnomalies()
    {
        return totalAnomalies;
    }

    public bool IsIndexInList(int index)
    {
        return anomaliesDiscovered.Contains(index);
    }

    public void SetAnomaliesDiscovered(List<int> savedAnomaliesDiscovered)
    {
        anomaliesDiscovered = savedAnomaliesDiscovered;
    }
}
