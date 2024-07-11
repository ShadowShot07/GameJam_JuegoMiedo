using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/RoomManager")]
public class RoomManagerScriptableObject : ScriptableObject
{
    [SerializeField] private int _room;
    public int currentRoom;
    public UnityEvent<int> roomChangeEvent;

    private void OnEnable()
    {
        _room = 0;
        currentRoom = 0;
        if (roomChangeEvent == null) { roomChangeEvent = new UnityEvent<int>(); }
    }

    public void CambioDeSala(int number)
    {
        _room = number;
        currentRoom = _room;
        roomChangeEvent.Invoke(_room);
    }
}
