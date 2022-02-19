using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Photon.MonoBehaviour
{
    public CharacterController controller;
    public float speed = 4f;
    public AudioSource source;
    public GameObject PlayerCamera;
    public PhotonView photonView;

    Animator anim;

    void Start() {
    
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

        if (photonView.isMine)
        {
            PlayerCamera.SetActive(true);
        }
        if (!photonView.isMine)
        {
            PlayerCamera.SetActive(false); 
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (photonView.isMine)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                speed = 3f;
                GameManager.instance.PickedUp();
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                speed = 4f;
                GameManager.instance.Dropped();
            }
            else
            {
                CheckInput();
            }
        }
    }

    void CheckInput()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (((move * speed * Time.deltaTime).magnitude > 0) && source.isPlaying != true)
        {
            source.volume = Random.Range(0.8f, 1);
            source.pitch = Random.Range(0.8f, 1.1f);
            source.Play();
        }

        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("runCheck", true);
            anim.SetBool("idleCheck", false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("runCheck", true);
            anim.SetBool("idleCheck", false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("runCheck", true);
            anim.SetBool("idleCheck", false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("runCheck", true);
            anim.SetBool("idleCheck", false);
        }
        else
        {
            anim.SetBool("runCheck", false);
            anim.SetBool("idleCheck", true);
        }
    }
}
