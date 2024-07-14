using UnityEngine;

public class FinalController : MonoBehaviour
{
    [SerializeField] private Animator _finalAnimator;
    [SerializeField] private GameObject _finalCanvas;
    
    public void StartCanvas()
    {
        _finalCanvas.SetActive(true);
        _finalAnimator.Play("AnimacionDelFinal");
        GameGlobal.instance.disablePlayer.Invoke();
    }

    public void StopCanvas()
    {
        _finalCanvas.SetActive(false);
    }
}
