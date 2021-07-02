using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class trigger : MonoBehaviour
{
    public UnityEvent triggerEvent;
    // Start is called before the first frame update
    void Start()
    {
        UnityEvent triggerEvent = new UnityEvent();
    }

    // Update is called once per frame
    // void Update()
    //{

    //}
    private void OnTriggerEnter(Collider other)
    {
        triggerEvent.Invoke();
    }
}
