using System.Collections;
using System.Collections.Generic;
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

    [Header("Lista de Objetos")]
    [SerializeField] private AnomalysObjects[] _objectsInstantiate;
    [SerializeField] private List<int> _objectsInstantiateIndex;

    [Header("Numero Random del index")]
    [SerializeField] private int _randomObjectIndex;
    [SerializeField] private float _randomObjects;

    [Header("Screamer")]
    [SerializeField] private Screamer _screamer;

    // Variables de posiciones para los TP
    private Vector3 _playerDirection;
    private Vector3 _exitPosition;
    private Vector3 _enteringPosition;
    private GameObject _enteringGameObject;

    private void Start()
    {
        for (int i = 0; i < _objectsInstantiate.Length; i++)
        {
            _objectsInstantiateIndex.Add(i);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerDirection = other.gameObject.transform.position - transform.position;
            if (RoomManager.currentRoom >= 0 && RoomManager.currentRoom < RoomManager.finalRoom -1)
            {
                if (RoomManager.currentAnomaly == null)
                {
                    _nextRoom = RoomManager.currentRoom + 1;
                    TakeAnomalyObjects();
                }
                else if (RoomManager.currentAnomaly != null)
                {
                    _nextRoom = 0;
                    StartScreamer();
                    RoomManager.currentAnomaly.AnomalySwitch();
                    RoomManager.currentAnomaly = null;
                }
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

    private void TakeAnomalyObjects()
    {
        _randomObjects = Random.Range(0f, 1f);
        if (_randomObjects < 0.8f && RoomManager.cleanAnomalyObjects == false)
        {
            _randomObjectIndex = Random.Range(0, _objectsInstantiateIndex.Count);
            RoomManager.currentAnomaly = _objectsInstantiate[_randomObjectIndex];
            RoomManager.currentAnomaly.AnomalySwitch();
            _objectsInstantiateIndex.Remove(_randomObjectIndex);
            ResetAnomalyAllObjects();
        }
        else if (RoomManager.cleanAnomalyObjects == true)
        {
            RoomManager.cleanAnomalyObjects = false;
        }
        Debug.Log(_randomObjects);
    }

    private void ResetAnomalyAllObjects()
    {
        if (_objectsInstantiateIndex.Count == 0)
        {
            for (int i = 0; i < _objectsInstantiate.Length; i++)
            {
                _objectsInstantiateIndex.Add(i);
            }
        }
    }

    public void StartScreamer()
    {
        StartCoroutine(_screamer.IScreamer());
        RoomManager.backCount = 0;
    }
}
