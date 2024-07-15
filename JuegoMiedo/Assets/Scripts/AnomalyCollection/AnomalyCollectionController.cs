using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnomalyCollectionController : MonoBehaviour
{
    [SerializeField] private GameObject discoveredPanel;
    [SerializeField] private Animator anim;
    [SerializeField] private AnomalyCollectionData anomalyCollectionData;
    [SerializeField] private TMP_Text anomalyDiscoveredNumbers;
   


    private void OnEnable()
    {
        GameGlobal.instance.newAnomalyCleaned.AddListener(OnAnomalyCleaned);
    }

    private void OnDisable()
    {
        GameGlobal.instance.newAnomalyCleaned.RemoveListener(OnAnomalyCleaned);
    }

    private void OnAnomalyCleaned(int index)
    {
        if (!anomalyCollectionData.IsIndexInList(index))
        {
            anomalyCollectionData.AddAnomalyDiscovered(index);
            anomalyDiscoveredNumbers.text = (anomalyCollectionData.GetAnomaliesDiscovered() + " / 10").ToString();
            anim.Play("Show");
        }
       
    }
}
