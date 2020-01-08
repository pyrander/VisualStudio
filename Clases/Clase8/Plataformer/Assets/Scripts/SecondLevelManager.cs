using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondLevelManager : MonoBehaviour
{

    public Transform startPos;
    // Start is called before the first frame update
    void Start()
    {
        Player.setPosition = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
