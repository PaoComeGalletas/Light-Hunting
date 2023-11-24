using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharController_Motor : MonoBehaviour
{
   
    public float speed = 10.0f;
    public float sensitivity = 30.0f;
    public float WaterHeight = 15.5f;
    private CharacterController character; // Cambio: Declarar la variable como 'private' en lugar de 'public'
    public GameObject cam;
    float moveFB, moveLR;
    float rotX, rotY;
    public bool webGLRightClickRotation = true;
    float gravity = -9.8f;
    bool cursorLocked = true;

    public float jumpForce = 10.0f; // Fuerza del salto.
    bool isGrounded = false;

    void Start()
    {
       
        character = GetComponent<CharacterController>();
        if (Application.isEditor)
        {
            webGLRightClickRotation = false;
            sensitivity = sensitivity * 1.5f;
        }

        LockCursor();
    }

    void CheckForWaterHeight()
    {
        if (transform.position.y < WaterHeight)
        {
            gravity = 0f;
        }
        else
        {
            gravity = -9.8f;
        }
    }

    void Update()
    {
        moveFB = Input.GetAxis("Horizontal") * speed;
        moveLR = Input.GetAxis("Vertical") * speed;

        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY = -Input.GetAxis("Mouse Y") * sensitivity;

        CheckForWaterHeight();

        CameraRotation(cam, rotX, rotY);

        isGrounded = character.isGrounded; // Comprueba si el personaje está en el suelo.

        if (isGrounded)
        {
            if (Input.GetKeyDown("space")) // Detecta si se ha presionado la tecla de salto.
            {
                character.Move(Vector3.up * jumpForce * Time.deltaTime); // Aplica la fuerza de salto.
            }
        }

        Vector3 movement = new Vector3(moveFB, gravity, moveLR);
        movement = transform.rotation * movement;
        character.Move(movement * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLocked = !cursorLocked;
            LockCursor();
        }
    }

    void CameraRotation(GameObject cam, float rotX, float rotY)
    {
        transform.Rotate(0, rotX * Time.deltaTime, 0);
        cam.transform.Rotate(rotY * Time.deltaTime, 0, 0);
    }

    void LockCursor()
    {
        if (cursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
   
}
