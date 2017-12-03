using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowBehaviour : MonoBehaviour {
    public GameObject Player;
	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.gameObject.GetComponent<NavMeshAgent>().SetDestination(Player.transform.position);
	}
}
