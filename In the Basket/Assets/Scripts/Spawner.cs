using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] hazards;

    private float timeBtwSpawns;
    public float startTimeBtwSpawns;

    public GameObject player;

    private GameObject randomSpawnPoint;

    private GameObject[] spawnPoints;

    // Update is called once per frame
    void Update()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("spawnPoints");
        GameObject oldPoint = GameObject.FindGameObjectWithTag("oldPoint");

        if (timeBtwSpawns <= 0)
        {
            setSpawnPoint();
              GameObject randomHazard = hazards[Random.Range(0, hazards.Length)];

            if (oldPoint.transform.position == randomSpawnPoint.transform.position)
            {
                setSpawnPoint();
            }

            if (oldPoint.transform.position == randomSpawnPoint.transform.position)
            {
                setSpawnPoint();
            }

            if (oldPoint.transform.position == randomSpawnPoint.transform.position)
            {
                setSpawnPoint();
            }

            if (oldPoint.transform.position == randomSpawnPoint.transform.position)
            {
                setSpawnPoint();
            }

            if (oldPoint.transform.position == randomSpawnPoint.transform.position)
            {
                setSpawnPoint();
            }

            Instantiate(randomHazard, randomSpawnPoint.transform.position, Quaternion.identity);

              oldPoint.transform.position = randomSpawnPoint.transform.position;

              timeBtwSpawns = startTimeBtwSpawns;
        }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
    }

    public void setSpawnPoint()
    {
        randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
    }
}
