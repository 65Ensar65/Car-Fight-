using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDeadController : ICarDeadable
{
    public void GetDeadController(GameObject carObj, GameObject carSolver, GameObject carSphere)
    {
        carObj.SetActive(false);
        carSphere.SetActive(false);
        carSolver.SetActive(false);
        GameManager.Instance.Enemys.Remove(carObj.transform);
        GameManager.Instance.GetGameWinControl();
    }
}
