using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    [SerializeField] float m_time;
    public Vector3 m_playerOffset;
    [SerializeField] Transform m_player;

    void FixedUpdate()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, m_playerOffset + m_player.position, m_time * Time.fixedDeltaTime);
    }
}
