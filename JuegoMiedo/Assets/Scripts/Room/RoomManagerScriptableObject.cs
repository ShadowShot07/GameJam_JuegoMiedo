using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/RoomManager")]
public class RoomManagerScriptableObject : ScriptableObject
{
    [Header("Habitaciones")]
    [SerializeField] private int _room;
    public int currentRoom;
    public int finalRoom;

    [Header("Conteo para atras")]
    public int backCount;

    [Header("Anomalia")]
    public GameObject currentAnomaly;
    public bool cleanAnomalyObjects;
    public bool haveScreamer;

    [Header("Eventos")]
    public UnityEvent<int> roomChangeEvent;

    private void OnEnable()
    {
        _room = 0;
        currentRoom = 0;
        finalRoom = 5;
        backCount = 0;
        cleanAnomalyObjects = false;
        haveScreamer = false;
        currentAnomaly = null;
        if (roomChangeEvent == null) { roomChangeEvent = new UnityEvent<int>(); }
    }

    public void CambioDeSala(int number)
    {
        _room = number;
        currentRoom = _room;
        roomChangeEvent.Invoke(_room);
    }
}
