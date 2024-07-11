using UnityEngine;

public class NextRoomTrigger : MonoBehaviour
{
    [Header("Habitaciones")]
    [SerializeField] private RoomManagerScriptableObject RoomManager;
    [SerializeField] private int _nextRoom;

    [Header("Opciones del TP")]
    [SerializeField] private Collider _tpTarget;
    [SerializeField] private Vector3 _zFixOffSet;

    [Header("Enseñar Canvas Final")]
    [SerializeField] private bool _finalIsActive = false;
    [SerializeField] private GameObject _finalCanvas;

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
            if (RoomManager.currentRoom >= 0 && RoomManager.currentRoom < RoomManager.finalRoom -1)
            {
                _nextRoom = RoomManager.currentRoom + 1;
                RoomManager.CambioDeSala(_nextRoom);

                TeleportNextRoomIn(other.gameObject, _playerDirection);
            }
            else if (RoomManager.currentRoom == RoomManager.finalRoom -1)
            {
                Debug.Log("Holi estoy en la sala final");
                _finalIsActive = true;
                _finalCanvas.SetActive(_finalIsActive);
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
        _exitPosition = _tpTarget.transform.position + pos + _zFixOffSet;
        gameObject.transform.position = _exitPosition;
    }
}
