using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFallController : Base
{
    public List<Transform> FractureCube = new List<Transform>();
    void Start()
    {
        InvokeRepeating(nameof(GetFallController), 5, 5);
    }

    void GetFallController()
    {
        if (FractureCube.Count != 0)
        {
            int rndNumber = Random.Range(0, FractureCube.Count);
            FractureCube[rndNumber].DOMoveY(-500, 25);
            FractureCube.Remove(FractureCube[rndNumber]);
        }
    }
}
