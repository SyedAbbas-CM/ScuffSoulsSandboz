using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    public float damage = 2f;
    public float radius = 1f;
    public LayerMask layermask;


    private void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius,layermask);
        if (hits.Length > 0)
        {
            print("We touched" + hits[0].gameObject.tag);
            gameObject.SetActive(false);
        }


    }

}
