using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Base
{
    private IPlayerJoystickable playerJoystickable;
    private IPlayerHitForceable playerHitForceable;
    private ICarTurretable playerTurretable;
    private ICarDeadable playerDeadable;
    private IUIPlayerLookable playerLookable;

    /*Player Hit Force Values*/
    private float jumpForce;
    private float returnForce;

    /*Player Look UI Values*/
    private Camera gameCamera;

    [Title("Player Joystick Values")]
    public float RotateSmooth;
    public float MoveSpeed;

    [Title("Player Type Values")]
    public ObjectType PlayerType;

    [Title("Player Hit Force Values")]
    public bool IsHit = true;

    [Title("Player Turret Values")]
    public GameObject CarTurret;
    public float TurretActiveSpeed;

    [Title("Player Fall Values")]
    public GameObject CarSolver;
    public Transform CarBall;

    [Title("Player Look UI Values")]
    public Transform LookUI;

    void Start()
    {
        playerJoystickable = new PlayerJoystickController();
        playerJoystickable.SetJoystickParameters(transform, e_rigidbody, e_joystick, RotateSmooth);

        playerHitForceable = new PlayerHitForceController();

        playerTurretable = new CarTurretController();
        playerTurretable.SetTurretParameters(CarTurret, TurretActiveSpeed, CarBall);

        playerDeadable = new CarDeadController();

        playerLookable = new PlayerLookController();
        gameCamera = Camera.main;
    }

    void Update()
    {
        playerJoystickable.GetJoystickController(MoveSpeed);
    }

    private void LateUpdate()
    {
        playerLookable.GetLookController(gameCamera, LookUI);
    }

    void GetForceHitControl(Transform hitBall, float minJump, float maxJump, float minReturn, float maxReturn)
    {
        playerHitForceable.GetHitForceController(jumpForce, returnForce, e_playerController, e_rigidbody, hitBall, transform, minJump, maxJump, minReturn, maxReturn);
        transform.GetChild(3).GetComponent<ParticleSystem>().Play();
    }

    void GetSelectFunch(ObjectType type, Transform transform)
    {
        switch (type)
        {
            case ObjectType.EnemyBall1:
                GetForceHitControl(transform, 3, 5, 3, 6);
                break;
            case ObjectType.EnemyBall2:
                GetForceHitControl(transform, 3, 5, 3, 6);
                break;
            case ObjectType.EnemyBall3:
                GetForceHitControl(transform, 3, 5, 3, 6);
                break;
            case ObjectType.EnemyBall4:
                GetForceHitControl(transform, 3, 5, 3, 6);
                break;
            case ObjectType.AirTurretDrop:
                playerTurretable.GetTurretController();
                break;
            case ObjectType.AirBallDrop:
                playerTurretable.GetCarBallController();
                CarBall.GetComponent<BallController>().GetBallScaleController();
                break;
            case ObjectType.FallWall:
                Invoke(nameof(GetPlayerDeadcontroller), 1.5f);
                break;
            case ObjectType.TurretBullet:
                GetForceHitControl(transform, 20, 30, 10, 20);
                break;
            case ObjectType.Platform:
                e_playerController.enabled = true;
                break;
            default:
                break;
        }
    }

    private void GetPlayerDeadcontroller()
    {
        playerDeadable.GetDeadController(gameObject, CarSolver, CarBall.gameObject);
        GameManager.Instance.GetLoseController();
        Destroy(transform.GetChild(3));
    }
    private void OnTriggerStay(Collider other)
    {
        other.transform.GetComponent<IInteract>()?.Interact(PlayerType, transform, GetSelectFunch);
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerController playerController = GetComponent<PlayerController>();
        if (playerController != null)
        {
            e_rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionY;
            playerController.enabled = false;
        }
    }

}
