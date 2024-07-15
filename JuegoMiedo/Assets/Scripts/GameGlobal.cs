using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameGlobal : MonoBehaviour
{
    public static GameGlobal instance;
    public float globalSensitivity;

    public UnityEvent inGameMenuOn;
    public UnityEvent inGameMenuOff;
    public UnityEvent disablePlayer;
    public UnityEvent<int> newAnomalyCleaned;


    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);  
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
