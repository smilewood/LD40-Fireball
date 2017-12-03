using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthTracker : MonoBehaviour {
    public int health;
    public GameObject armorDrop;
    public int dropAmmount;
    public GameObject deathEffect;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void HitMe()
    {
        health -= 1;
        if (health <= 0)
        {
            Destroy(this.gameObject);
            GameObject armor = Instantiate(armorDrop, this.gameObject.transform.position + new Vector3(0,.5f,0), Quaternion.identity);
            armor.GetComponent<pickupArmor>().ammount = dropAmmount;
            GameObject deathSparks = Instantiate(deathEffect, this.transform.position, Quaternion.identity);
            Destroy(deathSparks, deathSparks.GetComponent<ParticleSystem>().main.duration);
        }
    }
}
