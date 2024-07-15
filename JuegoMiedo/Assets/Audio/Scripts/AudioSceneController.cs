using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSceneController : MonoBehaviour
{
    [SerializeField] private float scarySoundAverageTime;
    [SerializeField] [Range(0f, 10f)] private float scarySoundTimeRandomize;
    [SerializeField] private GameObject scarySoundObject;

    [SerializeField] private Vector3 scaryObjectRandomizePosition;

    private float time;
    private float scaryTime;

    private Vector3 scarySoundObjectPosition;

    private GameObject player;

    private bool isActive = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        AudioManager.instance.StartGameAmbience();
        scaryTime = scarySoundAverageTime + Random.Range(-scarySoundTimeRandomize, scarySoundTimeRandomize);
    }

    private void OnEnable()
    {
        GameGlobal.instance.disablePlayer.AddListener(OnEnd);
    }
    private void OnDisable()
    {
        GameGlobal.instance.disablePlayer.RemoveListener(OnEnd);
    }

    private void Update()
    {
        if (isActive)
        {
            time += Time.deltaTime;
            if (time >= scaryTime)
            {
                PlayScarySoundFromScaryObject();
                time = 0f;
            }
        }
    }

    private void PlayScarySoundFromScaryObject()
    {
        scarySoundObjectPosition = GenerateRandomPositionArroundPlayer();
        scarySoundObject.transform.position = scarySoundObjectPosition;
        AudioManager.instance.PlayScarySound(scarySoundObject);
        scaryTime = scarySoundAverageTime + Random.Range(-scarySoundTimeRandomize, scarySoundTimeRandomize);
        Debug.Log("RANDOM POS; " + scarySoundObjectPosition);
        Debug.Log("RANDOM TIME; " + scaryTime);
        Debug.Log("Forward: " + player.transform.forward);

    }

    private Vector3 GenerateRandomPositionArroundPlayer()
    {
        Vector3 randomizePosition = new Vector3(Random.Range(-1f, 1f) * scaryObjectRandomizePosition.x, 
            Random.Range(-1f, 1f) * scaryObjectRandomizePosition.y, 
            Random.Range(0f, 1f) * scaryObjectRandomizePosition.z);
        
        Vector3 objectPosition = player.transform.localPosition - player.transform.forward * randomizePosition.z + 
            player.transform.right * randomizePosition.x + player.transform.up * randomizePosition.y;

        return objectPosition;
    }

    private void OnEnd()
    {
        isActive = false;
    }

}
