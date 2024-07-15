using UnityEngine;

public class InstruccionesChange : MonoBehaviour
{
    [SerializeField] private RoomManagerScriptableObject RoomManagerScriptableObject;
    [SerializeField] private GameObject _decal;

    private void Update()
    {
        if (RoomManagerScriptableObject.currentRoom != 0)
        {
            _decal.SetActive(false);
        }
        else
        {
            _decal.SetActive(true);
        }
    }
}
