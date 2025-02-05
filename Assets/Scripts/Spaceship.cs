using System;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    private void FixedUpdate()
    {
        this.Movement();
        //throw new NotImplementedException();
    }

    void Movement()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0) * 0.1f;
        transform.Translate(move, Space.World);
    }
}
