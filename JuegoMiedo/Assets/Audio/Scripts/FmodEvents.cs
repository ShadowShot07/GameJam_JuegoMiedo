using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FmodEvents : MonoBehaviour
{
    [field: Header("Main Theme")]
    [field: SerializeField] public EventReference playMainTheme {get; private set;}

    [field: Header("Game Theme")]
    [field: SerializeField] public EventReference playGameTheme { get; private set; }

    [field: Header("Footsteps")]
    [field: SerializeField] public EventReference playChildFootstep { get; private set; }

    [field: Header("HeartBeat")]
    [field: SerializeField] public EventReference playHeartBeat { get; private set; }
   
    [field: Header("UI Accept")]
    [field: SerializeField] public EventReference playUIAccept { get; private set; }
    
    [field: Header("UI Cancel")]
    [field: SerializeField] public EventReference playUICancel { get; private set; }

    public static FmodEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogError("Found more than one AudioManager in the scene!!!");
            Debug.LogError("Destroying new instance!!!");
            Destroy(this);

        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
