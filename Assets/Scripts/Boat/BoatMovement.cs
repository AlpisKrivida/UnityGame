using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoatMovement : MonoBehaviour
{
    public float movespeed = 50;
    public float turnSpeed = 30;
    public float rotationSpeed = 30;
    public float Stabilization = 30;

    public float maxLeftRotate = 200;
    public float maxRightRotate = 200;

    public GameObject boat;
    public GameObject target;

    Vector3 userDirectionLeft = Vector3.left;
    Vector3 userDirectionRight = Vector3.right;
    Vector3 userDirectionForward = Vector3.forward;
    Vector3 userDirectionBack = Vector3.back;

    private float timeCount = 0.0f;

    private Rigidbody br;
    //private float timer=0;
    //private float waitTime = 2;
    //private bool triggered = false;
    private float yaxis;
    private bool jump = false;
    private bool pressed = false;
    public float jumpDist;
    public float jumpSpeed;
    public float fallSpeed;

    private InputManager inputManager;
    public GameObject pauseMenu;
    public GameObject keyMenu;
    public GameObject soundMenu;



    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.visible = true;
        br = boat.GetComponent<Rigidbody>();
        inputManager = InputManager.instance;
        yaxis = gameObject.transform.position.y;
    }

    // Update is called once per frame
    private void Jump()
    {
        if (jump)
        {
            if (gameObject.transform.position.y < jumpDist)
            {
                gameObject.transform.Translate(0, Time.deltaTime * jumpSpeed, 0);
            }
            else
            {
                jump = false;
            }
        }
        if (jump == false && gameObject.transform.position.y > yaxis)
        {
            gameObject.transform.Translate(0, -Time.deltaTime * jumpSpeed, 0);
        }
        else if (jump == false)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, yaxis, gameObject.transform.position.z);
            pressed = false;
        }
    }


    void Update()
    {
        br = boat.GetComponent<Rigidbody>();
        transform.Translate(Vector3.forward * movespeed * Time.deltaTime);

        if (inputManager.KeyDown("Jump") && pressed == false)
        {
            jump = true;
            pressed = true;
        }

        Jump();

        if (boat.transform.position.y > 19.4)
        {
            br.useGravity = true;
        }
        else
        {
            br.velocity = Vector3.zero;
            br.angularVelocity = Vector3.zero;
            br.useGravity = false;
        }

        if (inputManager.KeyDown("MoveRight"))
        {
            transform.Translate(userDirectionRight * movespeed * Time.deltaTime);
            if (boat.transform.localEulerAngles.y < maxLeftRotate)
            {
                boat.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
                timeCount = 0;
            }

        }

        if (inputManager.KeyDown("MoveLeft"))
        {
            transform.Translate(userDirectionLeft * movespeed * 0.5f * Time.deltaTime);

            if (boat.transform.localEulerAngles.y > maxRightRotate)
            {
                transform.Translate(userDirectionLeft * movespeed * Time.deltaTime);
                boat.transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
                timeCount = 0;
            }
        }

        if (/*Input.anyKey == false*/!inputManager.KeyDown("MoveLeft") && !inputManager.KeyDown("MoveRight") && boat.transform.localEulerAngles.y > 180 || boat.transform.localEulerAngles.y < 180)
        {
            Quaternion newQuaternion = new Quaternion();
            newQuaternion.Set(270, 180, 0, 1);
            if (!inputManager.KeyDown("MoveRight") && !inputManager.KeyDown("MoveLeft"))
            {
                boat.transform.rotation = Quaternion.Slerp(boat.transform.rotation, Quaternion.Euler(270, 180, 0), timeCount);
                timeCount = timeCount + Time.deltaTime;
            }
        }

        if (inputManager.GetKeyDown("Pause"))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
            else if(Time.timeScale == 0 && !keyMenu.activeSelf && !soundMenu.activeSelf)
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
        }
    }
}
