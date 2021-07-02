using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{

    private bool move = false;
    private Vector3 target;
    private float cameraSpeed = 6;
    public Vector3 tehilaPos;
    public Vector3 nirPos;
    private Vector3 togetherPos;
    public Vector3 finalPos;
    // Start is called before the first frame update
    void Start()
    {
        togetherPos = transform.position;
        //target = tehilaPos;
    }

    public void startFinishSequence()
    {
        move = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (move)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, cameraSpeed * Time.fixedDeltaTime);
        }
    }

    public void changePosToTehila()
    {
        target = tehilaPos;
        move = true;
        Invoke("stopMove",5);
    }

    public void changePosToNir()
    {
        target = nirPos;
        move = true;
        Invoke("stopMove", 10);
    }

    public void changePosToTogether()
    {
        target = togetherPos;
        move = true;
        Invoke("stopMove", 5);
    }

    public void changePosToFinal()
    {
        target = finalPos;
        move = true;
        Invoke("stopMove", 5);
    }
        
    public void stopMove()
    {
        move = false;
    }
}
