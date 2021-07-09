using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController controller;
    public float speed;
    public float jumpHeight;
    private float jumpVelocity;
    public float gravity;
    public float horizontalSpeed;
    private bool isMovingRight;
    private bool isMovingLeft;

    public GameObject serialReader;
    bool[] bt;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        isMovingRight = false;
        isMovingLeft = false;
        bt = GameObject.Find("SerialReader").GetComponent<arduinoInputScript>().buttons;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.forward * speed;

        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space) || bt[3])
            {
                jumpVelocity = jumpHeight;
            }

            if ((Input.GetKeyDown(KeyCode.A) || bt[0]) && transform.position.x > -2.8f && isMovingLeft == false) 
            {
                Debug.Log("Precionou para Esquerda!");
                isMovingLeft = true;
                leftMoveFunc();
                //StartCoroutine(LeftMove());
            }

            if ((Input.GetKeyDown(KeyCode.D) || bt[1]) && transform.position.x < 2.8f && isMovingRight == false)
            {
                Debug.Log("Precionou para Direita!");
                isMovingRight = true;
                rightMoveFunc();
                //StartCoroutine(RightMove());
            }
        }
        else {
            jumpVelocity -= gravity;
        }

        direction.y = jumpVelocity;

        controller.Move(direction * Time.deltaTime);
    }

    void leftMoveFunc()
    {
        while (transform.position.x > -3)
        {
            controller.Move(Vector3.left * Time.deltaTime * horizontalSpeed);
        }
        isMovingLeft = false;
    }

    void rightMoveFunc()
    {
        while (transform.position.x < 3)
        {
            controller.Move(Vector3.right * Time.deltaTime * horizontalSpeed);
        }
        isMovingLeft = false;
    }
    IEnumerator LeftMove() 
    {
        Debug.Log("Coroutine para esquerda ativa!");
        for(float i = 0; i < 10; i += 0.1f)
        {
            controller.Move(Vector3.left * Time.deltaTime * horizontalSpeed);
            yield return null;
        }
        
    }

    IEnumerator RightMove()
    {
        Debug.Log("Coroutine para direita ativa!");
        for (float i = 0; i < 10; i += 0.1f)
        {
            controller.Move(Vector3.right * Time.deltaTime * horizontalSpeed);
            yield return null;
        }
    }
}
