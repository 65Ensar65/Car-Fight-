using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookController : IUIPlayerLookable
{
    public void GetLookController(Camera gameCamera, Transform lookUI)
    {
        Vector3 camPos = gameCamera.transform.position;

        lookUI.transform.LookAt(new Vector3(camPos.x, camPos.y, camPos.z));
    }
}
