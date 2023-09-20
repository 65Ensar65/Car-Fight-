using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Base
{
    /*Enemy Interface Values*/
    private IEnemyHitForceable enemyHitForceable;
    private IEnemyPatrolable enemyPatrolable;
    private IEnemyOverlapable enemyOverlapable;
    private ICarTurretable carTurretable;
    private ICarDeadable carDeadable;

    /*Enemy Hit Force Values*/
    private float jumpForce;
    private float returnForce;

    /*Enemy Overlap Values*/
    private bool _inside;

    [Title("Enemy Force Values")]
    public EnemyActiveController EnemyActiveController;

    [Title("Enemy Type Values")]
    public ObjectType EnemyType;

    [Title("Enemy Patrol Values")]
    public List<Transform> PointList;
    public float PointDistance;
    public float EnemySpeed;
    public int EnemyIndex;
    public bool IsPatrol;

    [Title("Enemy Overlap Values")]
    public Vector3 OverlapScale = Vector3.one;
    public LayerMask EnemyLayers;
    public float RotateSpeed;
    public bool IsFree;

    [Title("Enemy Turret Controller")]
    public GameObject CarTurret;
    public float TurretActiveSpeed;
    public Transform CarBall;

    [Title("Enemy Fall Values")]
    public GameObject EnemySphere;
    public GameObject EnemySolver;

    private void Start()
    {
        enemyHitForceable = new EnemyForceHitController();

        enemyOverlapable = new EnemyOverlapController();
        enemyOverlapable.SetOverlapParameters(transform, RotateSpeed);

        enemyPatrolable = new EnemyPatrolController();
        enemyPatrolable.SetPatrolParameters(PointList, transform, PointDistance);

        carTurretable = new CarTurretController();
        carTurretable.SetTurretParameters(CarTurret, TurretActiveSpeed, CarBall);

        carDeadable = new CarDeadController(); 
    }

    private void FixedUpdate()
    {
        if (IsFree)
        {
            enemyPatrolable.GetPatrolController(EnemySpeed, ref EnemyIndex, IsPatrol);
        }
        enemyOverlapable.GetOverlapController(OverlapScale, EnemyLayers, ref _inside, transform, EnemySpeed, ref IsPatrol);
    }

    void GetForceHitControl(Transform hitBall, float minJump, float maxJump, float minReturn, float maxReturn)
    {
        enemyHitForceable.GetHitForceController(jumpForce, returnForce, e_enemyController, e_rigidbody, hitBall, transform, EnemyActiveController, EnemySpeed,
                                                minJump, maxJump, minReturn, maxReturn);
        transform.GetChild(3).GetComponent<ParticleSystem>().Play();
    }

    private void GetDeadController()
    {
        carDeadable.GetDeadController(gameObject, EnemySolver, EnemySphere);
        transform.GetChild(2).GetComponent<TurretController>().enabled = false;
        GetComponent<EnemyController>().enabled = false;
    }

    void GetSelectFunch(ObjectType type, Transform transform)
    {
        switch (type)
        {
            case ObjectType.PlayerBall:
                GameManager.Instance.GetCameraAnimController();
                GetForceHitControl(transform, 3, 5.5f, 1, 5);
                break;
            case ObjectType.EnemyBall1:
                GetForceHitControl(transform, 3, 5.5f, 1, 5);
                break;
            case ObjectType.EnemyBall2:
                GetForceHitControl(transform, 3, 5.5f, 1, 5);
                break;
            case ObjectType.EnemyBall3:
                GetForceHitControl(transform, 3, 5.5f, 1, 5);
                break;
            case ObjectType.EnemyBall4:
                GetForceHitControl(transform, 3, 5.5f, 1, 5);
                break;
            case ObjectType.AirTurretDrop:
                carTurretable.GetTurretController();
                break;
            case ObjectType.AirBallDrop:
                carTurretable.GetCarBallController();
                break;
            case ObjectType.FallWall:
                Invoke(nameof(GetDeadController), 1.5f);
                break;
            case ObjectType.TurretBullet:
                GetForceHitControl(transform, 20, 30f, 10, 20);
                break;
            default:
                break;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        other.GetComponent<IInteract>()?.Interact(EnemyType, other.transform, GetSelectFunch);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Vector3 position = transform.position;

        Gizmos.DrawWireCube(position, OverlapScale * 2);
    }
}
