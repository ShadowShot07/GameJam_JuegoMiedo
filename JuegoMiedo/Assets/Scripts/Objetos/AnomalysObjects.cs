using UnityEngine;

public class AnomalysObjects : MonoBehaviour
{
    [SerializeField] private Animator _animatior;

    public bool _haveAnomaly = false;

    public void AnomalySwitch()
    {
        if (_haveAnomaly)
        {
            //_animationAnomaly.Play();
            Debug.Log("Yo soy normal jeje");
            _haveAnomaly = false;
        } 
        else if (!_haveAnomaly)
        {
            Debug.Log("Soy Anomalo grrrrr");
            _haveAnomaly = true;
            //_animationNormal.Play();
        }
    }
}
