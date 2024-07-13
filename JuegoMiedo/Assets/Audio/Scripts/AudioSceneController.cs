using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSceneController : MonoBehaviour
{
    [SerializeField] private float scarySoundAverageTime;
    [SerializeField] [Range(0f, 5f)] private float scarySoundTimeRandomize;
    [SerializeField] private GameObject scarySoundObject;

    [SerializeField] private Vector3 scaryObjectRandomizePosition;

    private float time;

    private Vector3 scarySoundObjectPosition;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        AudioManager.instance.StartGameAmbience();
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= scarySoundAverageTime)
        {
            PlayScarySoundFromScaryObject();
            time = 0f;
        }
    }

    private void PlayScarySoundFromScaryObject()
    {
        scarySoundObjectPosition = GenerateRandomPositionArroundPlayer();
        scarySoundObject.transform.position = scarySoundObjectPosition;
        AudioManager.instance.PlayScarySound(scarySoundObject);
    }

    private Vector3 GenerateRandomPositionArroundPlayer()
    {
        Vector3 randomPosition = player.transform.position - (Vector3.Scale(player.transform.forward, scaryObjectRandomizePosition));
        return randomPosition;
    }


}
