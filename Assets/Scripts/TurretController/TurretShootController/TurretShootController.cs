using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShootController : ITurretShootable
{
    public void GetTurretShootController(Transform turret, Transform bulletPos, ObjectPool objectPool, ParticleSystem shootParticle)
    {
        objectPool.ActivePoolObject(ObjectTag.TurretBullet, bulletPos);
        shootParticle.Play();
    }
}
