using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class land : MonoBehaviour
{
    private float speed = 7;
    private Rigidbody rb;
    public int dir;
    private Vector3 startPoint;
    private bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position;
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, speed * dir);
        Invoke("restartLand", 3f);
    }

    private void restartLand()
    {
        if (canMove)
        {
            transform.position = startPoint;
            Invoke("restartLand", 3f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void stop()
    {
        canMove = false;
        rb.velocity = Vector3.zero;
    }
}
