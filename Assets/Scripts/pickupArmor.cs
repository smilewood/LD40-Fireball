using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupArmor : MonoBehaviour {
    public int ammount;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            col.gameObject.GetComponent<PlayerArmorTracker>().ChangeArmor(ammount);
            Destroy(this.gameObject);
        }
    }
}
