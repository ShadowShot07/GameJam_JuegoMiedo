using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/RoomManager")]
public class RoomManagerScriptableObject : ScriptableObject
{
    [SerializeField] private int _room;
    public int currentRoom;
    public int finalRoom;

    // Evento Cambio de Habitación
    public UnityEvent<int> roomChangeEvent;

    private void OnEnable()
    {
        _room = 0;
        currentRoom = 0;
        finalRoom = 5;
        if (roomChangeEvent == null) { roomChangeEvent = new UnityEvent<int>(); }
    }

    public void CambioDeSala(int number)
    {
        _room = number;
        currentRoom = _room;
        roomChangeEvent.Invoke(_room);
    }
}
