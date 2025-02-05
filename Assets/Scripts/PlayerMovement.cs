using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(0,0,1*Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal")*0.1f, 0, Input.GetAxis("Vertical")*0.1f);
        move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        //move = new Vector3(0, 0, 1) * Time.deltaTime;
        //move = Vector3.forward * 3 * Time.deltaTime;
        transform.Translate(move, Space.Self);
    }
}
