using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : Base
{
    private ITurretShootable turretShootable;

    [Title("Turret Shoot Controller")]
    public Transform TurretPoint;
    public ParticleSystem ShootParticle;

    void Start()
    {
        turretShootable = new TurretShootController();
        InvokeRepeating(nameof(GetTurretShootController), 3, 3);
    }

    void GetTurretShootController()
    {
        turretShootable.GetTurretShootController(transform, TurretPoint, e_objectPool, ShootParticle);
    }
}
