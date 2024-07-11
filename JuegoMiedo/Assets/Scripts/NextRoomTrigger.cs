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
                other.transform.position = _tpTarget.transform.position + new Vector3(other.transform.position.x, 0, _tpTarget.transform.position.z + 0.1f);
            }
        }
    }
}
