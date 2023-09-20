using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [HideInInspector] public Rigidbody e_rigidbody;
    [HideInInspector] public Collider e_collider;
    [HideInInspector] public Animator e_animator;
    [HideInInspector] public SphereCollider e_sphereCollider;
    [HideInInspector] public MeshRenderer e_meshRenderer;
    [HideInInspector] public ObjectPool e_objectPool;
    [HideInInspector] public Joystick e_joystick;
    [HideInInspector] public PlayerController e_playerController;
    [HideInInspector] public EnemyController e_enemyController;
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        e_rigidbody = (GetComponent<Rigidbody>()) ? GetComponent<Rigidbody>() : null;
        e_collider = (GetComponent<Collider>()) ? GetComponent<Collider>() : null;
        e_animator = (GetComponent<Animator>()) ? GetComponent<Animator>() : null;
        e_meshRenderer = GetComponent<MeshRenderer>() ? GetComponent<MeshRenderer>() : null;
        e_sphereCollider = GetComponent<SphereCollider>() ? GetComponent<SphereCollider>() : null;
        e_objectPool = (FindObjectOfType<ObjectPool>()) ? FindObjectOfType<ObjectPool>() : null;
        e_joystick = (FindObjectOfType<Joystick>()) ? FindObjectOfType<Joystick>() : null;
        e_playerController = (FindObjectOfType<PlayerController>()) ? FindObjectOfType<PlayerController>() : null;
        e_enemyController = (FindObjectOfType<EnemyController>()) ? FindObjectOfType<EnemyController>() : null;
    }
}
