using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITurretShootable
{
    void GetTurretShootController(Transform turret, Transform bulletPos, ObjectPool objectPool, ParticleSystem shootParticle);
}