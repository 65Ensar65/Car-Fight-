using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTurretController : ICarTurretable
{
    private GameObject _carTurret;
    private float _turretActiveSpeed;
    private Transform _carBall;
    public void SetTurretParameters(GameObject carTurret, float turretActiveSpeed, Transform carBall)
    {
        _carTurret = carTurret;
        _turretActiveSpeed = turretActiveSpeed;
        _carBall = carBall;
    }
    public void GetTurretController()
    {
        _carTurret.SetActive(true);
        _carTurret.GetComponent<TurretController>().enabled = true;
        _carTurret.transform.DOScale(new Vector3(.77f, .77f, .77f), _turretActiveSpeed);
    }

    public void GetCarBallController()
    {
        _carBall.DOScale(new Vector3(1.5f, 1.5f, 1.5f), .3f);
    }

    public void GetCarPassiveScaleController()
    {
        _carBall.DOScale(new Vector3(1.1f, 1.1f, 1.1f), .3f);
    }
}
