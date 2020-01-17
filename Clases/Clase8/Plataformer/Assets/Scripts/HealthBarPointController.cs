using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarPointController : MonoBehaviour {

    private float width;
    public RectTransform bar;
    public RectTransform barPoint;
    private bool isDamage;
    public float maxLife = 39;
    public float _currentLife;
    public float CurrentLife {
        set {
            isDamage = Mathf.Clamp (_currentLife, 0, maxLife) > value;
            _currentLife = Mathf.Clamp (value, 0, maxLife);
            BarUpdate ();
            
        }
        get {
            return _currentLife;
        }
    }



    // Start is called before the first frame update
    void Start ()
    {
        width = barPoint.sizeDelta.x;
        _currentLife = 0;
    }

    // Update is called once per frame
    void Update ()
    {

        //curLife = Mathf.Clamp (curLife,0,maxLife);
        //bar.fillAmount = curLife/maxLife;
    }


    void BarUpdate ()
    {
        ClearLife ();
        if (!isDamage) {
            AddLife (1);
        }


    }

    void AddLife (int index) {
        Debug.Log ("add life: " + _currentLife);
        for (int i = 0; i < _currentLife; i++) {
            RectTransform point = Instantiate<RectTransform> (barPoint);
            point.parent = bar;
            point.localScale = Vector3.one;
            float ancho = width * i;
            point.localPosition = new Vector3 (ancho, 0, 0);

        }    }

    void RemoveLife ()
    {

    }

    void ClearLife ()
    {
        for (int i = 0; i < bar.childCount; i++) {
            Destroy (bar.GetChild (i).gameObject);
        }
    }
}
