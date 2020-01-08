using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{

    public Image bar;
    public float maxLife = 50;
    public float curLife = 50;
    // Start is called before the first frame update
    void Start()
    {
        curLife = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.O)) {
            curLife--;
        }

        if (Input.GetKeyDown (KeyCode.P)) {
            curLife++;
        }

        curLife = Mathf.Clamp (curLife,0,maxLife);
        bar.fillAmount = curLife/maxLife;
    }
}
