using System.Collections;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public InputActionAsset InputActions;

    InputAction move;
    InputAction look;
    InputAction jump;
    InputAction sprint;
    InputAction pause;

    public Vector2 moveAmt;
    public Vector2 lookAmt;

    public Rigidbody rb;

    public float moveSpeed = 1;

    public float lookSpeed = 1;
    public float jumpSpeed = 1;
    public float airSpeed = .1f;

    public bool grounded = false;

    public bool canPause = true;

    private float xCamRotation = 0f;

    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();
    }




    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Get InputAction references from Project-wide input actions.
        if (InputSystem.actions)
        {
            move = InputSystem.actions.FindAction("Player/Move");
            look = InputSystem.actions.FindAction("Player/Look");
            jump = InputSystem.actions.FindAction("Player/Jump");
            sprint = InputSystem.actions.FindAction("Player/Sprint");
            pause = InputSystem.actions.FindAction("Player/Pause");
        }



    }

    private void Update()
    {

        moveAmt = move.ReadValue<Vector2>();
        lookAmt = look.ReadValue<Vector2>();




        Ray ray = new Ray(transform.position, -transform.up);
        Physics.Raycast(ray, out RaycastHit hit, 1.25f, Physics.AllLayers, QueryTriggerInteraction.Ignore);

        if (hit.collider != null)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }



        if (jump.WasPressedThisFrame())
        {
            Jump();
        }

     


    }

    private void FixedUpdate()
    {
        Walking();
        Rotating();



    }


    private void Walking()
    {
        rb.AddForce(transform.forward * moveAmt.y * moveSpeed, ForceMode.VelocityChange);
        rb.AddForce(transform.right * moveAmt.x * moveSpeed, ForceMode.VelocityChange);
    }


    private void Rotating()
    {
        transform.Rotate(Vector3.up, lookAmt.x * lookSpeed);

        xCamRotation -= lookAmt.y;
        xCamRotation = Mathf.Clamp(xCamRotation, -90f, 90f);

        Camera.main.transform.localRotation = Quaternion.Euler(xCamRotation, 0f, 0f);

    }

    public void Jump()
    {
        if(grounded)
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Force);
    }

}
