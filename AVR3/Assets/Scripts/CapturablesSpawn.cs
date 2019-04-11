using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapturablesSpawn : MonoBehaviour
{
    
    public float spawningInterval;
    public float spawningRadius;
    public StartGame startGame;

    private int numberSpawned;
    private Vector3 spawnPosition;
    private Vector3 cameraPos;

    private int arrayLength;

    public GameObject[] capturables;

    void Start ()
    {
        numberSpawned = 0;
        arrayLength = 2;
        cameraPos = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
        startGame.iStartGame += StartSpawning;
    }

    private void StartSpawning()
    {
        Debug.Log("startSpawn");
        StartCoroutine(SpawningRoutine());
    }

    void ChooseSpawnPosition()
    {
        spawnPosition = cameraPos + new Vector3(Random.Range(-spawningRadius, spawningRadius), Random.Range(-spawningRadius, spawningRadius), Random.Range(-spawningRadius, spawningRadius));
    }

    IEnumerator SpawningRoutine()
    {
        while (true)
        {
            ChooseSpawnPosition();
            GameObject capt = Instantiate(capturables[Random.Range(0, arrayLength)], spawnPosition, Quaternion.identity);
            float newScale = Random.Range(3f, 6f);
            capt.transform.localScale = new Vector3(newScale, newScale, newScale);
            numberSpawned++;
            switch (numberSpawned)
            {
                case 5:
                    arrayLength += 2;
                    break;

                case 10:
                    arrayLength += 2;
                    break;

                case 15:
                    arrayLength += 2;
                    break;
            }
            yield return new WaitForSeconds(spawningInterval);
        }
    }
}
