using System.Collections;
using UnityEngine;

public class Screamer : MonoBehaviour
{
    [SerializeField] private  GameObject canvasScreamer;
    [SerializeField] private float elapsed = 0f;
    [SerializeField] private float currentMagnitude = 1f;
    [SerializeField] private float duration = 1f;
    [SerializeField] private GameObject _camera;

    private void Start()
    {
        canvasScreamer.SetActive(false);
    }

    public IEnumerator IScreamer()
    {
        yield return new WaitForSeconds(1.5f);

        while (elapsed < duration)
        {
            float x = (Random.value - 0.5f) * currentMagnitude;
            float y = (Random.value - 0.5f) * currentMagnitude;

            _camera.transform.localPosition = new Vector3(x, y, 0f);

            elapsed += Time.deltaTime;
            currentMagnitude = (1 - (elapsed / duration)) * (1 - (elapsed / duration));
            canvasScreamer.SetActive(true);
            yield return null;
        }
        _camera.transform.localPosition = Vector3.zero;
        canvasScreamer.SetActive(false);
    }
}
