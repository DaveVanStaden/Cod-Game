using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private Text waveText;
    [SerializeField] private List<GameObject> spawnerHolder;
    [SerializeField] private List<GameObject> enemyHolder;
    private float enemyWave = 0;
    private float spawnedAmount;
    private float amountToSpawn = 5;

    private float countDown = 10;
    private float time;
    
    void Update()
    {
        waveText.text = "Wave: " + enemyWave;
        time += Time.deltaTime;
        if (time >= countDown && spawnedAmount < amountToSpawn)
        {
            var tempNumber = Random.Range(0, spawnerHolder.Count);
            var tempnumb2 = Random.Range(0, enemyHolder.Count);
            Instantiate(enemyHolder[tempnumb2], spawnerHolder[tempNumber].transform.position, Quaternion.identity);
            time = 0;
            spawnedAmount += 1;
        }
        if (spawnedAmount >= amountToSpawn)
        {
            enemyWave += 1;
            spawnedAmount = 0;
            amountToSpawn += 5;
            if (countDown >= 1)
            {
                countDown -= 1;
            }
        }
    }
}
