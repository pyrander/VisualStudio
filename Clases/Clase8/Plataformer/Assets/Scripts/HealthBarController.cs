using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{

    private float minScale = 0f;
    private float maxScale = 46f;
    public RectTransform barMiddle;
    public RectTransform barEnd;
    public float maxLife = 50;
    public float _currentLife;
    public float CurrentLife {
        set {
            _currentLife = Mathf.Clamp (value, 0, maxLife);
            BarUpdate ();
        }
        get {
            return _currentLife;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        _currentLife = maxLife;
    }

    // Update is called once per frame
    void Update()
    {

        //curLife = Mathf.Clamp (curLife,0,maxLife);
        //bar.fillAmount = curLife/maxLife;
    }


    void BarUpdate () {

        float lifePercent = _currentLife / maxLife;

        Vector3 scale = barMiddle.localScale;
        float targetScale = maxScale * lifePercent;
        scale.x = Mathf.Clamp (targetScale, minScale, maxScale);

        //Debug.Log (barMiddle.localScale);
        Vector3 pos = barEnd.localPosition;
        pos.x = barMiddle.localPosition.x + (barMiddle.sizeDelta.x * scale.x);
        barEnd.localPosition = pos;
        barMiddle.localScale = scale;
     }
}
