using System.Collections;
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

    [Header("Screamer")]
    [SerializeField] private Screamer _screamer;

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
            else if (RoomManager.currentRoom >= 1)
            {
                _previousRoom = RoomManager.currentRoom - 1;
                
                if (RoomManager.currentAnomaly == null)
                {
                    RoomManager.backCount++;
                    StartScreamer();
                }
                else if (RoomManager.currentAnomaly != null)
                {
                    StartCoroutine(CleanNextRoom());
                    ResetAnomalyObjects();
                }
                RoomManager.CambioDeSala(_previousRoom);
                TeleportPreviousRoomIn(other.gameObject, _playerDirection);
            }
        }
    }

    private void TeleportPreviousRoomIn(GameObject gameObject, Vector3 position)
    {
        _enteringGameObject = gameObject;
        _enteringPosition = position;
        TeleportPreviousRoomOut(_enteringGameObject, _enteringPosition);
    }

    private void TeleportPreviousRoomOut(GameObject gameObject, Vector3 pos)
    {
        _exitPosition = _tpTarget.transform.position + pos - _zFixOffSet;
        gameObject.transform.position = _exitPosition;
    }

    private void ResetAnomalyObjects()
    {
        RoomManager.currentAnomaly.GetComponent<AnomalysObjects>().AnomalySwitch();
        RoomManager.currentAnomaly = null;
    }

    public IEnumerator CleanNextRoom()
    {
        yield return new WaitForSeconds(3);
        RoomManager.cleanAnomalyObjects = true;
        // Audio tin campanita
        AudioManager.instance.PlayAnomalyCleaned();
        Debug.Log("Ta limpio");
    }

    public void StartScreamer()
    {
        if (RoomManager.backCount == 2)
        {
            RoomManager.backCount = 0;
            StartCoroutine(_screamer.IScreamer());
            _previousRoom = 0;
        }
    }
}
