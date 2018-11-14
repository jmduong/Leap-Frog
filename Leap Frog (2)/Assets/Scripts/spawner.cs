using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

    private float minTime = 0f;
    private float maxTime = 0.5f;

    private bool isSpawning = false;

    public GameObject lilypad;  // Array of enemy prefabs.

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        //We only want to spawn one at a time, so make sure we're not already making that call
        if (!isSpawning)
        {
            isSpawning = true; //Yep, we're going to spawn
            StartCoroutine(SpawnObject(Random.Range(minTime, maxTime)));
        }
    }

    IEnumerator SpawnObject(float seconds)
    {
        int spawnPointX = Random.Range(100, 350);
        Vector3 spawnPosition = new Vector3(spawnPointX, gameObject.transform.position.y, gameObject.transform.position.z);

        yield return new WaitForSeconds(seconds);
        Instantiate(lilypad, spawnPosition, transform.rotation);

        //We've spawned, so now we could start another spawn     
        isSpawning = false;
    }
}
