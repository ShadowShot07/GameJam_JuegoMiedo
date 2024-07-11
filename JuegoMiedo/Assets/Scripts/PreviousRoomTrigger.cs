using UnityEngine;

public class PreviousRoomTrigger : MonoBehaviour
{
    [SerializeField] private int _previousRoom;
    [SerializeField] private RoomManagerScriptableObject RoomManager;
    [SerializeField] private Transform _tpTarget;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (RoomManager.currentRoom == 0)
            {
                Debug.Log("Para atras no hay nada mas bobo");
            }
            else if (RoomManager.currentRoom == 1)
            {
                _previousRoom = RoomManager.currentRoom - 1;

                RoomManager.CambioDeSala(_previousRoom);
                other.transform.position = _tpTarget.transform.position + new Vector3(other.transform.position.x, 0, _tpTarget.transform.position.z - 0.1f);
                Debug.Log(other.transform.position.x + " X " + other.transform.position.y + " Y");
            }
        }
    }
}
