using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarySystem : MonoBehaviour
{
    private Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }



}
