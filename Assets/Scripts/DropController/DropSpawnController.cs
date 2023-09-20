using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawnController : Base
{
    public ObjectType AirDropType;
    void Start()
    {
        InvokeRepeating(nameof(GetSpawnController), 20, 20);
    }

    void GetSpawnController()
    {
        Vector3 pos = new Vector3(Random.Range(-6, 6), transform.position.y, Random.Range(-6, 6));
        transform.position = pos;
        ObjectTag objectTag = (ObjectTag)Random.Range(0,2);
        GameObject obj = e_objectPool.ActivePoolObject(objectTag, transform);
        obj.transform.rotation = Quaternion.Euler(-90, 0, 0);
    }
}
