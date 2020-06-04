using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour 
{

    public float damage = 2f;
    public float radius = 1f;
    public LayerMask layerMask;
    public float BossLevel = 1f;

    public bool is_boss;
    void Update() 
    {
        //save all the colliders hit into hits
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, layerMask);
        //check if there is anything in hits and apply damage
        if (hits.Length > 0) 
        {

            hits[0].gameObject.GetComponent<HealthScript>().ApplyDamage(damage);

            gameObject.SetActive(false);

        }
        //damage is 30 if the boss is attacking
        if (is_boss)
        {
            damage = 30;
        }
    }

} // class




























