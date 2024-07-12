using UnityEngine;

public class ScreamerEventManager : MonoBehaviour
{
    public delegate void ScreamerAction();
    public static event ScreamerAction OnScreamer;

    void ActivateScreamer()
    {
        OnScreamer();
    }
}
