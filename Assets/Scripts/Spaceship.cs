using System;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public float speed;
    private void FixedUpdate()
    {
        // The spaceship's movement is called in the FixedUpdate method
        // The spaceship's movement is called using the Movement method
        this.Movement();
        //throw new NotImplementedException();
    }

    void Movement()
    {
        // Move the spaceship horizontally
        // The spaceship moves right or left based on the horizontal input
        // The spaceship moves at a speed of 10 units per second
        // The spaceship's movement is frame rate independent
        // The spaceship's movement is clamped between -8.5 and 8.5 on the x-axis
        // The spaceship's position is updated using the Translate method
        // The spaceship's position is updated in the world space
        // The spaceship's position is updated using the horizontal input
        // The spaceship's position is updated using the speed variable, using the Time.deltaTime variable, using the right direction, using the Vector3 data type, using the move variable, using the Translate method
        Vector3 move = Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        // The spaceship's position is updated using the Translate method
        transform.Translate(move, Space.World);
        //Mathf.Clamp(transform.position.x, -8.5f, 8.5f);
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.5f, 8.5f), transform.position.y, transform.position.z);
        
        // Limit the spaceship's movement to the screen boundaries
        // The spaceship's position is clamped between -30 and 30 on the x-axis
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -30f, 30f);
        transform.position = pos;
    }
}
