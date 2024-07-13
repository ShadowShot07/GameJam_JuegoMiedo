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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
