using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpStrength = 10.0f;
    public float airControl = 1.0f;
    public float gravityModifier = 1.0f;
    public bool faceWithCamera = true;

    public Camera playerCamera;
    public GameObject playerOrbs;
    public Vector3 checkpoint;
    public GameObject menuScreen;

    private CharacterController _controller;
    [SerializeField]
    private Animator _animator;

    private Vector3 _desiredVelocity;
    private Vector3 _airVelocity;
    private bool _isJumpDesired = false;

    public bool isGrounded = false;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            _animator.enabled = false;
            _controller.enabled = false;
            menuScreen.SetActive(true);
        }

        if (other.gameObject.CompareTag("Checkpoint"))
        {
            checkpoint = other.transform.position;
        }

        if (other.gameObject.CompareTag("Killplane"))
        {
            menuScreen.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            _animator.enabled = false;
            _controller.enabled = false;
        }
    }


    private void Update()
    {
        //Get movement input
        float inputForward = Input.GetAxis("Vertical");
        float inputRight = Input.GetAxis("Horizontal");

        //Get camera forward
        Vector3 cameraForward = playerCamera.transform.forward;
        cameraForward.y = 0.0f;
        cameraForward.Normalize();
        //Get camera right
        Vector3 cameraRight = playerCamera.transform.right;

        //Find the desired velocity
        _desiredVelocity = (cameraForward * inputForward) + (cameraRight * inputRight);

        //Get jump input
        _isJumpDesired = Input.GetButtonDown("Jump");

        //Set movement magnitude
        _desiredVelocity.Normalize();
        _desiredVelocity *= speed;

        //Check for ground
        isGrounded = _controller.isGrounded;

        //Update animations
        if (faceWithCamera)
        {
            transform.forward = cameraForward;
            _animator.SetFloat("Speed", inputForward);
            _animator.SetFloat("Direction", inputRight);
        }
        else
        {
            if (_desiredVelocity != Vector3.zero)
                transform.forward = _desiredVelocity.normalized;
            _animator.SetFloat("Speed", _desiredVelocity.magnitude / speed);
        }
        _animator.SetBool("Jump", !isGrounded);
        _animator.SetFloat("VerticalSpeed", _desiredVelocity.y / jumpStrength);

        //Apply jump strength
        if (_isJumpDesired && isGrounded)
        {
            _airVelocity.y = jumpStrength;
            _isJumpDesired = false;
        }

        //Stop on ground
        if (isGrounded && _airVelocity.y < 0.0f)
        {
            _airVelocity.y = -1.0f;
        }

        //Apply gravity
        _airVelocity += Physics.gravity * gravityModifier * Time.deltaTime;

        //Add air velocity
        _desiredVelocity += _airVelocity;

        //Move
        _controller.Move(_desiredVelocity * Time.deltaTime);
    }
    
}
