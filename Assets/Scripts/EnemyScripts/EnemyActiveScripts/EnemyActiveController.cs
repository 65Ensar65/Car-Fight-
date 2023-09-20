using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActiveController : Base
{
    public EnemyController EnemyController;
    public Transform EnemyBall;
    public void GetActiveEnemyCar()
    {
        Invoke(nameof(GetDelayActive), 3.2f);
    }

    void GetDelayActive()
    {
        EnemyController.enabled = true;
        EnemyController.EnemySpeed = 0.05f;
        GetComponent<EnemyActiveController>().enabled = false;
    }
}
