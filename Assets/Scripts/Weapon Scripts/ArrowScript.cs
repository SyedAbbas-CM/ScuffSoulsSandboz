using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    private Rigidbody Rigidbody;
    public float speed= 30f;
    public float deactivate_Timer = 3f;
    public float damage = 30f;


    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Invoke("Deactivate", deactivate_Timer);
    }
    void Deactivate()
    {
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
        
    }
    private void OnTriggerEnter(Collider target)
    {
        //deactivate after collision
        Deactivate();
    }

    public void launch(Camera mainCamera)
    {
        Rigidbody.velocity = mainCamera.transform.forward * speed; // move it forward fro mthe camera times speed
        //rotate towards the velocity ig
        transform.LookAt(transform.position + Rigidbody.velocity);
        
    }
}
