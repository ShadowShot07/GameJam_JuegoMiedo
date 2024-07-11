using UnityEngine;

public class NextRoomTrigger : MonoBehaviour
{
    [SerializeField] private int _nextRoom;
    [SerializeField] private RoomManagerScriptableObject RoomManager;
    [SerializeField] private Transform _tpTarget;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (RoomManager.currentRoom == 0)
            {
                _nextRoom = RoomManager.currentRoom + 1;
                RoomManager.CambioDeSala(_nextRoom);
                other.transform.position = new Vector3(_tpTarget.transform.position.x, 0, other.transform.position.z);
            }
        }
    }
}
