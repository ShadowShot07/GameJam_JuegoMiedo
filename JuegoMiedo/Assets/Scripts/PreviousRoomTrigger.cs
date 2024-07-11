using UnityEngine;

public class PreviousRoomTrigger : MonoBehaviour
{
    [Header("Habitaciones")]
    [SerializeField] private RoomManagerScriptableObject RoomManager;
    [SerializeField] private int _previousRoom;

    [Header("Opciones del TP")]
    [SerializeField] private Collider _tpTarget;
    [SerializeField] private Vector3 _zFixOffSet;
    [SerializeField] private MeshCollider _collider;

    // Variables de posiciones para los TP
    private Vector3 _playerDirection;
    private Vector3 _exitPosition;
    private Vector3 _enteringPosition;
    private GameObject _enteringGameObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerDirection = other.gameObject.transform.position - transform.position;
            if (RoomManager.currentRoom == 0)
            {
                Debug.Log("Para atras no hay nada mas bobo");
                _collider.isTrigger = false;
            }
            else if (RoomManager.currentRoom >= 1 && RoomManager.currentRoom != RoomManager.finalRoom)
            {
                _collider.isTrigger = true;
                _previousRoom = RoomManager.currentRoom - 1;
                RoomManager.CambioDeSala(_previousRoom);
                TeleportNextRoomIn(other.gameObject, _playerDirection);
            }
        }
    }

    private void TeleportNextRoomIn(GameObject gameObject, Vector3 position)
    {
        _enteringGameObject = gameObject;
        _enteringPosition = position;
        TeleportNextRoomOut(_enteringGameObject, _enteringPosition);
    }

    private void TeleportNextRoomOut(GameObject gameObject, Vector3 pos)
    {
        _exitPosition = _tpTarget.transform.position + pos - _zFixOffSet;
        gameObject.transform.position = _exitPosition;
    }
}
