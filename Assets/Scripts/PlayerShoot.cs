using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    public LineRenderer lr;
    float ShootStartTime;
    public float shotTime;

    // Use this for initialization
    void Start () {
        lr.enabled = false;
    }
    public bool shooting = false;
    public GameObject hitEffect;
	// Update is called once per frame
	void Update () {
        if (shooting && Time.time - ShootStartTime > shotTime)
        {
            shooting = false;
            lr.enabled = false;
        }
        else
        {
            lr.SetPosition(0, Camera.main.ViewportToWorldPoint(new Vector3(1, .3f, 1)) + (Camera.main.transform.forward * -1));
            lr.SetPosition(2, Camera.main.ViewportToWorldPoint(new Vector3(0, .3f, 1)) + (Camera.main.transform.forward * -1));
        }
		if (!shooting && Input.GetMouseButtonDown(1))
        {
            shooting = true;
            Vector3 hitPoint = Camera.main.transform.position + (Camera.main.transform.forward * 4);
            RaycastHit hit;
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, .5f));
            //Debug.DrawRay(ray.origin, ray.direction * 100, Color.green, 20);

            if (Physics.Raycast(ray, out  hit, 4f))
            {
                hitPoint = hit.point;
                GameObject temp = Instantiate(
                    hitEffect, 
                    hitPoint, 
                    Quaternion.LookRotation(this.gameObject.transform.position - hitPoint));
                Destroy(temp, temp.GetComponent<ParticleSystem>().main.duration);
                if (hit.transform.tag == "Enemy")
                {
                    hit.transform.SendMessageUpwards("HitMe");
                }
            }

            lr.SetPosition(0, Camera.main.ViewportToWorldPoint(new Vector3(1,.3f,1)));
            lr.SetPosition(1, hitPoint);
            lr.SetPosition(2, Camera.main.ViewportToWorldPoint(new Vector3(0, .3f, 1)));

            lr.enabled = true;
            ShootStartTime = Time.time;
        }
	}

    Vector3 RotatePointAroundPivot( Vector3 point,  Vector3 pivot, Vector3 angles)
    {
        Vector3 dir = point - pivot; // get point direction relative to pivot
        dir = Quaternion.Euler(angles) * dir; // rotate it
        point = dir + pivot; // calculate rotated point
        return point; // return it
    }
}
