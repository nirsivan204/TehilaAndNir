using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class obstacles : MonoBehaviour
{
    public int dir;
    Rigidbody rb;
    public GameMGR gm;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.forward * (7) * dir;
        Invoke("destroy", 10);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gm.restart();
        }
    }
    private void destroy()
    {
        Destroy(this.gameObject);
    }
}
