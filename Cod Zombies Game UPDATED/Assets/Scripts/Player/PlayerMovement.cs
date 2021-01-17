using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 12f;
    [SerializeField] private CharacterController charController;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private float Stamina = 6f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;

    [SerializeField]private PlayerSaveLoad saveLoad;
    private Vector3 velocity;
    private bool isGrounded;
    private bool canRun;

    private bool CanLoad = true;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        charController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        charController.Move(velocity * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftShift) && Stamina > 0 && canRun == true)
        {
            speed = 20f;
            Stamina -= Time.deltaTime;
        }
        else
        {
            if (Stamina < 6)
                Stamina += Time.deltaTime;

            if (Stamina < 3)
                canRun = false;
            else canRun = true;
            speed = 12f;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            saveLoad.SavePlayer();
        }
        if (Input.GetKeyDown(KeyCode.L) && CanLoad)
        {
            saveLoad.LoadPlayer();
            CanLoad = false;
        }
    }
}
