using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A simple, rigidbody-based first person controller that supports mouse and keyboard input.
/// </summary>

public class Player : MonoBehaviour
{
    public CharacterController controller;

    // Adjustable settings for fine tuning movement.
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _sprintSpeed;
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float gravity;

    Vector3 velocity;
    float _speedBoost = 1f;

    private void Start()
    {
        // nothing lol
    }

    // Called once per frame. Dependent on hardware speed.
    private void Update()
    {
        // Rigidbody character controllers can have unexpected interactions with slopes. (Picture a marble going down a ramp.)
        // This is a somewhat hacky solution to a bug which causes the character to spin uncontrollaby if they move diagonally
        // on a slope.
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // MOVEMENT
        // Get our horizontal and horizontal inputs using Unity's input system. Note that vertical is the z axis, since we are in 3D space.
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // SPRINT
        // 
        if (Input.GetButton("Fire3"))
        {
            _speedBoost = _sprintSpeed;
        }
        else if (Input.GetButton("Fire1"))
        {
            _speedBoost = _walkSpeed;
        }
        else
        {
            _speedBoost = 1f;
        }

        Vector3 move = transform.right * xInput + transform.forward * zInput;

        // JUMP
        // Handling our jump is just like in our 2D project.
        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(_jumpHeight * -2f * gravity);
        }

        controller.Move(move * (_runSpeed + _speedBoost) * Time.deltaTime);

        // Finally we send our wishmove to the rigidbody to actually move through space.
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}