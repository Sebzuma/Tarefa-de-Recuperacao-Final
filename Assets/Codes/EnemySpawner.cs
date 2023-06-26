using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner: MonoBehaviour
{

    public GameObject enemyPrefab;
    public float spawnRadio = 3f;

    private GameObject player;
    private bool isNight = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        DayCicle dayCicle = FindObjectOfType<DayCicle>();
        if (dayCicle != null)
        {
            dayCicle.myNightCall += NightStarted;
            dayCicle.myMorningCall += NightEnded;
        }
    }

    private void NightStarted()
    {
        isNight = true;
        SpawnEnemy();
    }

    private void NightEnded()
    {
        isNight = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isNight)
        {
            if(Vector3.Distance(player.transform.position, transform.position) <= spawnRadio)
            {
                SpawnEnemy();
            }
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = player.transform.position + Random.insideUnitSphere * spawnRadio;
        spawnPosition.y = player.transform.position.y;

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
