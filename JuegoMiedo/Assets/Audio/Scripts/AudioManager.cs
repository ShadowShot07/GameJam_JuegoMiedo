using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    private EventInstance mainTheme;
    private EventInstance gameTheme;
    private EventInstance childFootsteps;
    private EventInstance heartBeat;
    private EventInstance uiAccept;
    private EventInstance uiCancel;


    [Header("Volume")]
    [Range(0, 1)]
    public float masterVolume = 1f;
    [Range(0, 1)]
    public float musicVolume = 1f;
    [Range(0, 1)]
    public float sfxVolume = 1f;

    private Bus masterBus;
    private Bus musicBus;
    private Bus sfxBus;

    public enum BusType
    {
        MASTER,
        MUSIC,
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

        //masterBus = RuntimeManager.GetBus("bus:/");
        //musicBus = RuntimeManager.GetBus("bus:/Music");
        //sfxBus = RuntimeManager.GetBus("bus:/SFX");

        CreateInstances();
    }

    private void CreateInstances()
    {
        mainTheme = CreateEventInstance(FmodEvents.instance.playMainTheme);
        childFootsteps = CreateEventInstance(FmodEvents.instance.playChildFootstep);
        heartBeat = CreateEventInstance(FmodEvents.instance.playHeartBeat);
        gameTheme = CreateEventInstance(FmodEvents.instance.playGameTheme);
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
    public void StartGameMusic()
    {
        gameTheme.start();
    }

    public void StopGameMusic()
    {
        gameTheme.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public void playChildFootstep()
    {
        childFootsteps.start();
    }

    public void PlayClimbing()
    {
        heartBeat.start();
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
