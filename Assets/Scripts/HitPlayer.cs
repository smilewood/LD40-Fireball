using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour {
    public int dammage;
    public GameObject root;
    public GameObject deathEffect;
   
    
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            col.gameObject.GetComponent<PlayerArmorTracker>().ChangeArmor(-dammage);
            GameObject deathSparks = Instantiate(deathEffect, this.transform.position, Quaternion.identity);
            Destroy(root);
            Destroy(deathSparks, deathSparks.GetComponent<ParticleSystem>().main.duration);
           
        }
    }
}