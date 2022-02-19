using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject Raccoon;
    public GameObject Crowbar;
    public GameObject Destination;
    public GameObject SceneCamera;
    public GameObject GameCanvas;
    public GameObject SelectionCanvas;
    public float XPosition;
    public float YPosition;
    public float XRPosition;
    public float YRPosition;
    public float ZPosiiton;
    public bool PlayerWon; 
    public static GameManager instance;

    private void Awake()
    {
        GameCanvas.SetActive(true);
        SelectionCanvas.SetActive(false);
        instance = this;
    }

    public void SpawnLimitP()
    {
        GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
        int NumberofPlayer = Players.Length;
        if (NumberofPlayer < 3)
        {
            PhotonNetwork.Instantiate(Player.name, new Vector3(XPosition, YPosition, 0f), Quaternion.identity, 0);
            SceneCamera.SetActive(false);
            GameCanvas.SetActive(false);
            
            //Tasks
            PhotonNetwork.Instantiate(Crowbar.name, new Vector3(XPosition, YPosition, ZPosiiton), Quaternion.identity, 0);
            PhotonNetwork.Instantiate(Destination.name, new Vector3(XPosition, YPosition, ZPosiiton), Quaternion.identity, 0);
        }
        else
        {
            SelectionCanvas.SetActive(true);
        }

    }
    public void SpawnLimitR()
    {
        GameObject[] Raccoons = GameObject.FindGameObjectsWithTag("Raccoon");
        int NumberofRaccoon = Raccoons.Length;
        if (NumberofRaccoon < 1)
        {
            PhotonNetwork.Instantiate(Raccoon.name, new Vector3(XRPosition, YRPosition, 20f), Quaternion.identity, 0);
            SceneCamera.SetActive(false);
            GameCanvas.SetActive(false);
        }
        else
        {
            SelectionCanvas.SetActive(true);
        }
    }
    public void PickedUp()
    {
        Player.tag = "HasCB";
        Crowbar.SetActive(false);
    }
    public void Dropped()
    {
        Player.tag = "Player";
        Crowbar.SetActive(true);
    }
    public void Winning()
    {
    }
}
