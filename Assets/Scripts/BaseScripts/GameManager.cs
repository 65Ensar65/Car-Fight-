using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : BaseSingleton<GameManager>
{
    [Title("Player Controller Values")]
    public PlayerController PlayerController;

    [Title("Enemys Check Values")]
    public List<Transform> Enemys = new List<Transform>();

    [Title("Camera Shake Values")]
    public CameraFollowController CameraAnim;

    [Title("Win Fail Values")]
    public GameObject WinPanel;
    public GameObject LosePanel;

    private void Update()
    {
       GetControlEnemys();
    }

    public void GetControlEnemys()
    {
        for (int i = 0; i < Enemys.Count; i++)
        {
            if (Enemys[i].GetComponent<EnemyController>().enabled == false && Enemys[i].GetComponent<CarRotate>().enabled == false)
            {
                Enemys[i].GetComponent<EnemyController>().enabled = true;
            }
        }
    }
    public void GetPlayerControllerActive()
    {
        Invoke(nameof(GetPlayerActive), 1.4f);
    }

    void GetPlayerActive()
    {
        PlayerController.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionY;
        PlayerController.transform.rotation = Quaternion.Euler(new Vector3(PlayerController.transform.eulerAngles.x, PlayerController.transform.eulerAngles.y,0));
    }

    public void GetCameraAnimController()
    {
        CameraAnim.m_playerOffset = new Vector3(0, 10, -7);
        Invoke(nameof(GetCameraAnimReturn), .4f);
    }

    void GetCameraAnimReturn()
    {
        CameraAnim.m_playerOffset = new Vector3(0, 11.9f, -8.36f);
    }

    public void GetGameWinControl()
    {
        if (Enemys.Count == 0)
        {
            WinPanel.SetActive(true);
            PlayerController.enabled = false;
            Destroy(LosePanel);
        }
    }

    public void GetLoseController()
    {
        LosePanel.SetActive(true);
        PlayerController.enabled = false;
        Destroy(WinPanel);
        for (int i = 0; i < Enemys.Count; i++)
        {
            Enemys[i].GetComponent<EnemyController>().enabled = false;
        }
    }

    public void GetRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
