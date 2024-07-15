using System.Collections;
using UnityEngine;

public class Screamer : MonoBehaviour
{
    [SerializeField] private float elapsed = 0f;
    [SerializeField] private float currentMagnitude = 1f;
    [SerializeField] private float duration = 1f;
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _screamerPrefab;
    [SerializeField] private GameObject _escenario;

    public IEnumerator IScreamer()
    {
        yield return new WaitForSeconds(1.5f);

        AudioManager.instance.PlayScream();

        _screamerPrefab.transform.SetParent(_camera.transform);
        _screamerPrefab.transform.position = _camera.transform.position + _camera.transform.forward;
        _screamerPrefab.transform.LookAt(_camera.transform.position);
        _screamerPrefab.SetActive(true);

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
        _screamerPrefab.transform.SetParent(_escenario.transform);
        _screamerPrefab.SetActive(false);
        elapsed = 0f;
    }
}
