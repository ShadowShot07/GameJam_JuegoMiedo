using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ChangeAvenue : MonoBehaviour
{
    [SerializeField] private RoomManagerScriptableObject RoomManagerScriptableObject;
    [SerializeField] private DecalProjector _decal;
    [SerializeField] private Texture[] _texturas;
    [SerializeField] private int _currentTexture = 0;

    private void Update()
    {
        if (_currentTexture != RoomManagerScriptableObject.currentRoom)
        {
            ChangeAvenueNumber();
        }
    }

    private void ChangeAvenueNumber()
    {
        _decal.material.SetTexture("Base_Map", _texturas[RoomManagerScriptableObject.currentRoom]);
        _currentTexture = RoomManagerScriptableObject.currentRoom;

    }
}
