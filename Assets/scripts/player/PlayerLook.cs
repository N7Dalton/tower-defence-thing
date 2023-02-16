using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;

    public float xSens = 30f;
    public float ySens = 30f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;
        //this calculates the cam rotation lookin up and down lol
        xRotation -= (mouseY * Time.deltaTime) * ySens;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        //this applies it to the cam
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        //rotates ding dong
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSens);
    }



}
