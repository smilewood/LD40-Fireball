using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour
{
    
    public Wave[] waves;
    public int wave = 0;
    public GameObject enemiyParent;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(Spawn());
    }
    public Text ContainmentText;
    public string containmentString;
    bool spawning;
    int spawned;
    private IEnumerator Spawn()
    {
        while (true)
        {
            spawning = true;
            spawned = 0;
            while (waves[wave].parts[0].count > spawned)
            {
                GameObject spawn = Instantiate(
                    waves[wave].parts[0].enemyType,
                    this.gameObject.transform.position,
                    Quaternion.identity,
                    enemiyParent.transform);
                spawn.GetComponent<NavMeshAgent>().speed = (spawn.GetComponent<NavMeshAgent>().speed + ((Random.Range(0.0f, 2.0f)) - 1.0f));
                ++spawned;
                yield return new WaitForSeconds(waves[wave].parts[0].spawnSpeed);
            }
            spawning = false;
            //wave = wave == waves.Length-1 ? wave : wave + 1;
            ++wave;
            if (ContainmentText)
                ContainmentText.text = (containmentString + " " + (int)((wave/(float)waves.Length)*100) + "%");
            while (enemiyParent.transform.childCount > 0)
            {
                yield return new WaitForSeconds(1);
            }
            if (wave == waves.Length)
            {
                if (ContainmentText)
                {
                    ContainmentText.gameObject.SendMessageUpwards("Win");
                }
                break;
            }
            yield return new WaitForSeconds(5);
        }
    }
}
