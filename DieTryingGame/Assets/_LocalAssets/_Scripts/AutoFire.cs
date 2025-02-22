using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.TopDownEngine;
using UnityEngine;

public class AutoFire : MonoBehaviour
{

    //public event Action OnGameStart;
    public WeaponHandler weaponHandler;
    // Start is called before the first frame update

    private bool areLasersOn;

    void Start()
    {
        
        if(weaponHandler == null)
        {
            weaponHandler = FindObjectOfType<WeaponHandler>();
        }
        
        weaponHandler.StopShooting();
        areLasersOn = false;
    }

    void Update()
    {
        if(!areLasersOn)
        {
            weaponHandler.StartShooting();
            areLasersOn = true;
        }
        
    }


}
