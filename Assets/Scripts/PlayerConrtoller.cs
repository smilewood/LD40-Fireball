using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConrtoller : MonoBehaviour
{
    public float speed;
    public float mouseSensitivity;
    public float jump;

    float verticalRotation = 0;
    public float upDownRange = 60.0f;

    public float vSpeed = 0;
    // Use this for initialization
    void Start()
    {
        //Screen.lockCursor = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotateLR = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotateLR, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        float speedF = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float speedH = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector3 move = new Vector3(speedH, vSpeed, speedF);





        move = transform.rotation * move;
        CharacterController cc = GetComponent<CharacterController>();
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (vSpeed < 0)
                vSpeed = 0;
            vSpeed += jump;
        }*/
        vSpeed += (Physics.gravity.y/2) * Time.deltaTime;
        if (cc.isGrounded)
        {
            vSpeed = 0;
        }

            
        cc.Move(move);

    }


}
