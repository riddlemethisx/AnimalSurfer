using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{


    private CharacterController controller;
    private Vector3 direction;

    public float forwardSpeed;
    public float maxSpeed;





    private int desiredLine = 1;
    public float laneDistance = 4;




    public bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;



    public float jumpForce;

    public float Gravity = -20;

    public Animator animator;
    private bool isSliding = false;

    void Start()
    {
        Application.targetFrameRate = 60;

        controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        if (!PlayerManager.isGameStarted)   //a�a��dakilerin hepsini oyun ba�lad���nda yap demektir
            return;




        if (forwardSpeed < maxSpeed)
            forwardSpeed += 0.1f * Time.deltaTime;




        animator.SetBool("isGameStarted", true);
        direction.z = forwardSpeed;


        isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);

        if (isGrounded)  //controller.isGrounded         if'in i�i bu �ekildeydi
        {
            //direction.y = -1;
            if (Input.GetKeyDown(KeyCode.UpArrow) || SwipeManager.swipeUp)
            {
                Jump();
            }
        }
        else
        {
            direction.y += Gravity * Time.deltaTime;
        }




        if ((Input.GetKeyDown(KeyCode.DownArrow) || SwipeManager.swipeDown) && !isSliding)
        {
            StartCoroutine(Slide());
        }






        if (Input.GetKeyDown(KeyCode.RightArrow) || SwipeManager.swipeRight)
        {
            desiredLine++;
            if (desiredLine == 3)
                desiredLine = 2;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || SwipeManager.swipeLeft)
        {
            desiredLine--;
            if (desiredLine == -1)
                desiredLine = 0;
        }


        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;


        if (desiredLine == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLine == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }



        #region D�ZELT�LM�� KISIM
        if (transform.position != targetPosition)
        {
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.sqrMagnitude)
                controller.Move(moveDir);
            else
                controller.Move(diff);
        }
        controller.Move(direction * Time.deltaTime);
        #endregion

    }
    private void FixedUpdate()
    {
        //if (!PlayerManager.isGameStarted)
        //    return;
        //controller.Move(direction * Time.fixedDeltaTime);

    }
    private IEnumerator Slide()
    {
        isSliding = true;
        animator.SetBool("isSliding", true);
        controller.center = new Vector3(0, -0.5f, 0);
        controller.height = 1;

        yield return new WaitForSeconds(1f);      //bu s�re ne kadar artarsa slide animasyonu o kadar oynat�l�r
        animator.SetBool("isSliding", false);

        controller.center = new Vector3(0, 0, 0);
        controller.height = 2;
        isSliding = false;
    }

    
    private void Jump()
    {
        direction.y = jumpForce;
    }




    [SerializeField] private AudioManager audioManager = null;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            PlayerManager.gameOver = true;
            audioManager.PlaySound("GameOver");
        }
    }










}
