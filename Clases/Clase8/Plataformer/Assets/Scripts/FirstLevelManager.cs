﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevelManager : MonoBehaviour
{
    public HealthBarController healthBar;
    public HealthBarPointController healthBarPoint;


    // Start is called before the first frame update
    void Start()
    {
        Player.HealthBar = healthBar;
        Player.HealthBarPoint = healthBarPoint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
