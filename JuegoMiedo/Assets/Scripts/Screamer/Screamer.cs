using System.Collections;
using UnityEngine;

public class Screamer : MonoBehaviour
{
    [SerializeField] private float elapsed = 0f;
    [SerializeField] private float currentMagnitude = 1f;
    [SerializeField] private float duration = 1f;
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _screamerObject;

    private void Start()
    {
        
    }

    public IEnumerator IScreamer()
    {
        yield return new WaitForSeconds(1.5f);

        AudioManager.instance.PlayScream();
        _screamerObject.SetActive(true);
        _screamerObject.transform.position = _camera.transform.position + _camera.transform.forward;
        while (elapsed < duration)
        {
            float x = (Random.value - 0.5f) * currentMagnitude;
            float y = (Random.value - 0.5f) * currentMagnitude;

            _camera.transform.localPosition = new Vector3(x, y, 0f);

            elapsed += Time.deltaTime;
            currentMagnitude = (1 - (elapsed / duration)) * (1 - (elapsed / duration));

            yield return null;
        }
        _camera.transform.localPosition = Vector3.zero;
        _screamerObject.SetActive(false);
    }
}
