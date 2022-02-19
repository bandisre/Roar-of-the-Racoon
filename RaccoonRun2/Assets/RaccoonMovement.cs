using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaccoonMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 4f;
    public AudioSource source;
    public GameObject RaccoonCamera;
    public PhotonView photonView;

    Animator anim;

    void Start()
    {
        source = GetComponent<AudioSource>();

        anim = GetComponent<Animator>();

        if (photonView.isMine)
        {
            RaccoonCamera.SetActive(true);
        }
        if (!photonView.isMine)
        {
            RaccoonCamera.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (photonView.isMine)
        {
            CheckInput();
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
            anim.SetBool("movingCheck", true);
            anim.SetBool("idleCheck", false);
            anim.SetBool("lungeCheck", false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("movingCheck", true);
            anim.SetBool("idleCheck", false);
            anim.SetBool("lungeCheck", false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("movingCheck", true);
            anim.SetBool("idleCheck", false);
            anim.SetBool("lungeCheck", false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("movingCheck", true);
            anim.SetBool("idleCheck", false);
            anim.SetBool("lungeCheck", false);
        }
        else
        {
            anim.SetBool("movingCheck", false);
            anim.SetBool("idleCheck", true);
            anim.SetBool("lungeCheck", false);
        }


        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("movingCheck", false);
            anim.SetBool("lungeCheck", true);

        }
        else
        {
            anim.SetBool("lungeCHeck", false);
        }
    }
}
