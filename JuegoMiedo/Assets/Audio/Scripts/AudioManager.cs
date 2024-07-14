using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    private EventInstance mainTheme;
    private EventInstance endTheme;
    private EventInstance gameAmbience;
    private EventInstance childFootsteps;
    private EventInstance heartBeat;
    private EventInstance scream;
    private EventInstance anomalyCleaned;
    private EventInstance uiAccept;
    private EventInstance uiCancel;


    [Header("Volume")]
    [Range(0, 1)]
    public float masterVolume = .8f;
    [Range(0, 1)]
    public float musicVolume = .8f;
    [Range(0, 1)]
    public float ambienceVolume = .8f;
    [Range(0, 1)]
    public float sfxVolume = .8f;

    private Bus masterBus;
    private Bus musicBus;
    private Bus ambienceBus;
    private Bus sfxBus;

    public enum BusType
    {
        MASTER,
        MUSIC,
        AMBIENCE,
        SFX
    }

    public static AudioManager instance { get; private set; }

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

        masterBus = RuntimeManager.GetBus("bus:/");
        musicBus = RuntimeManager.GetBus("bus:/Music");
        ambienceBus = RuntimeManager.GetBus("bus:/Ambience");
        sfxBus = RuntimeManager.GetBus("bus:/SFX");

        //CreateInstances();
    }

    private void Start()
    {
        CreateInstances();
    }

    private void CreateInstances()
    {
        mainTheme = CreateEventInstance(FmodEvents.instance.playMainTheme);
        endTheme = CreateEventInstance(FmodEvents.instance.playEndTheme);
        gameAmbience = CreateEventInstance(FmodEvents.instance.playGameAmbience);
        childFootsteps = CreateEventInstance(FmodEvents.instance.playChildFootstep);
        scream = CreateEventInstance(FmodEvents.instance.playScream);
        heartBeat = CreateEventInstance(FmodEvents.instance.playHeartBeat);
        anomalyCleaned = CreateEventInstance(FmodEvents.instance.playAnomalyCleaned);
        uiAccept = CreateEventInstance(FmodEvents.instance.playUIAccept);
        uiCancel = CreateEventInstance(FmodEvents.instance.playUICancel);
    }

    public void StartMusic()
    {
        mainTheme.start();
    }

    public void StopMusic()
    {
        mainTheme.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
    public void StartEndMusic()
    {
        endTheme.start();
    }

    public void StopEndMusic()
    {
        endTheme.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
    public void StartGameAmbience()
    {
        gameAmbience.start();
    }

    public void StopGameAmbience()
    {
        gameAmbience.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public void playChildFootstep()
    {
        childFootsteps.start();
    }

    public void PlayHeartBeat()
    {
        heartBeat.start();
    }

    public void PlayScream()
    {
        scream.start();
        heartBeat.start();
    }

    public void PlayAnomalyCleaned()
    {
        anomalyCleaned.start();  
    }

    public void PlayScarySound(GameObject soundObject)
    {
        RuntimeManager.PlayOneShotAttached(FmodEvents.instance.playScarySound, soundObject);
    }

    public void PlayUIAccept()
    {
        uiAccept.start();
    }

    public void PlayUICancel()
    {
        uiCancel.start();
    }

    public EventInstance CreateEventInstance(EventReference eventReference) 
    {
        EventInstance newEventInstance = RuntimeManager.CreateInstance(eventReference);
        return newEventInstance;
    }

    public void ChangeBusVolume(BusType bus, float newVolume)
    {
        switch (bus)
        {
            case BusType.MASTER:
                masterVolume = newVolume;
                masterBus.setVolume(masterVolume);
                break;
            case BusType.MUSIC:
                musicVolume = newVolume;
                musicBus.setVolume(musicVolume);
                break;
            case BusType.AMBIENCE:
                ambienceVolume = newVolume;
                ambienceBus.setVolume(ambienceVolume);
                break;
            case BusType.SFX:
                sfxVolume = newVolume;
                sfxBus.setVolume(sfxVolume);
                break;
            default:
                Debug.Log("Bus Type not supported: " + bus);
                break;
        }
    }

}
