using Runemark.SCEMA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankLoading : MonoBehaviour
{

    [SerializeField] private Location toMenuScene;

    void Start()
    {
        toMenuScene.Enter();
    }

    
}
