using Runemark.SCEMA;
using UnityEngine;

public class FinalController : MonoBehaviour
{
    [SerializeField] private Animator _finalAnimator;
    [SerializeField] private GameObject _finalCanvas;
    [SerializeField] private Location toMainMenu;
    [SerializeField] private GameObject _player;
    
    public void StartCanvas()
    {
        AudioManager.instance.StopGameAmbience();
        AudioManager.instance.StartEndMusic();

        _finalCanvas.SetActive(true);
        _finalAnimator.Play("AnimacionDelFinal");
        GameGlobal.instance.disablePlayer.Invoke();

        _player.SetActive(false);
    }

    public void StopCanvas()
    {
        _finalCanvas.SetActive(false);
    }

    private void ToMainMenu()
    {
        AudioManager.instance.StopEndMusic();
        toMainMenu.Enter();
    }
}
