using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoAnomalo : MonoBehaviour
{

    [SerializeField] private Animator anim;

    [SerializeField] private float anomalyTime;

    private float time;
    private bool isAnomaly = false;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= anomalyTime)
        {
            SwitchObject();
            time = 0f;
        }
    }

    private void SwitchObject()
    {
        if (isAnomaly)
        {
            anim.SetBool("Anomalo", false);
            isAnomaly = false;
        }
        else
        {
            anim.SetBool("Anomalo", true);
            isAnomaly = true;
        }

    }
}
