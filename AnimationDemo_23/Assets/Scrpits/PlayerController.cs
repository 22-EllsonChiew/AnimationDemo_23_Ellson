using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float JumpForce;
    public Animator PlayerAnimation;
    bool IsDead = false;
    int trackDeath = 10;
    
    bool isGrounded = true;

    Rigidbody playerRb;




    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //float Inputvertical = Input.GetAxis("Vertical");
        //float Inputhorizontal = Input.GetAxis("Horizontal");


        //transform.Translate(Vector3.forward * Time.deltaTime * Inputvertical * speed);
        //transform.Translate(Vector3.right * Time.deltaTime * Inputhorizontal * speed);

        if (IsDead ==  false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                PlayerAnimation.SetBool("IsMove", true);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                PlayerAnimation.SetBool("IsMove", true);
            }
            else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {
                PlayerAnimation.SetBool("IsMove", false);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, -90, 0);
                PlayerAnimation.SetBool("IsMove", true);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 90, 0);
                PlayerAnimation.SetBool("IsMove", true);
            }
            else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                PlayerAnimation.SetBool("IsMove", false);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
                PlayerAnimation.SetTrigger("IsFlip");
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                trackDeath--;

                if(trackDeath == 0)
                {
                    PlayerAnimation.SetTrigger("TrigDeath");
                    IsDead = true;
                }

            }
        }
        
        
            }

    }

    

