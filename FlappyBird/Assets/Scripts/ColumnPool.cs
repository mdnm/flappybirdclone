using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    [SerializeField] private GameObject columnPrefab;                             
    [SerializeField] private int columnPoolSize = 5;                   
    [SerializeField] private float spawnRate = 3f;                  
    [SerializeField] private float columnMin = -1f;              
    [SerializeField] private float columnMax = 3.5f;                              

    private GameObject[] columns;                       
    private int currentColumn = 0;                                

    private Vector2 objectPoolPosition = new Vector2 (-15,-25);    
    private float spawnXPosition = 10f;

    private float timeSinceLastSpawned;


    void Start()
    {
        timeSinceLastSpawned = 0f;

        columns = new GameObject[columnPoolSize];

        for(int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameManager.Instance.GameOver == false && timeSinceLastSpawned >= spawnRate) 
        {    
            timeSinceLastSpawned = 0f;

            float spawnYPosition = Random.Range(columnMin, columnMax);

            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);

            currentColumn ++;

            if (currentColumn >= columnPoolSize) 
            {
                currentColumn = 0;
            }
        }
    }
}
