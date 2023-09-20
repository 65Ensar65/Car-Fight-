using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRotate : Base
{
    private void Start()
    {
        InvokeRepeating(nameof(GetPatrol), 5,5);
    }
    void FixedUpdate()
    {
        transform.Rotate(0, 8, 0);      
    }

    void GetPatrol()
    {
        e_enemyController.IsFree = true;
        e_enemyController.enabled = true;
        GetComponent<CarRotate>().enabled = false;
    }
}
