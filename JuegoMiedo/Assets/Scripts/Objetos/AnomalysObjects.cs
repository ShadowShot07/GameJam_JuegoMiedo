using UnityEngine;

public class AnomalysObjects : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private bool _changeModel;
    [SerializeField] private bool _haveAnomaly = false;

    public void AnomalySwitch()
    {
        if (_haveAnomaly)
        {
            _animator.SetBool("Anomalo", false);
            Debug.Log("Yo soy normal jeje");
            _haveAnomaly = false;
        } 
        else
        {
            _animator.SetBool("Anomalo", true);
            Debug.Log("Soy Anomalo grrrrr");
            _haveAnomaly = true;
        }
    }
}
