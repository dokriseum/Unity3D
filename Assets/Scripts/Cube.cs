using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cube : MonoBehaviour
{
    public List<Material> materials; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            GetComponent<Renderer>().material = this.materials.Find(m => m.name == "Red");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            GetComponent<Renderer>().material = this.materials.Find(m => m.name == "Green");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            GetComponent<Renderer>().material = this.materials.Find(m => m.name == "Blue");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Renderer>().material = this.materials.Find(m => m.name == "Wood");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            GetComponent<Renderer>().material = this.materials.Find(m => m.name == "Conquit");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<Renderer>().material = this.materials.Find(m => m.name == "Stone");
        }
    }
}
