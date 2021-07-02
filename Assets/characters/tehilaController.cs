using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class tehilaController : MonoBehaviour
{
    protected Rigidbody rb;

    private Animator animator;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnJump()
    {
        rb.AddForce(Vector3.up * 6,ForceMode.Impulse);
       // rb.AddForce(Vector3.forward * -300, ForceMode.Acceleration);
       // transform.chil
        animator.SetTrigger("frontTwist");
    }
}
