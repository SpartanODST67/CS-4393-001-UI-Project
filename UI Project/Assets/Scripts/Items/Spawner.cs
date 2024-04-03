using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Object Spawn Data")]
    [SerializeField] GameObject spawnPrefab;
    [SerializeField] Vector3 spawnPosition;

    [Header("Spawner Parameters")]
    [SerializeField] float spawnWaitSeconds;
    [SerializeField] bool spawnOnStart;
    [SerializeField] bool spawningItem = false;

    [Header("Gizmos Parameters")]
    [SerializeField] Vector3 spawnerGizmoDimensions;
    [SerializeField] float itemGizmoRadius;

    // Start is called before the first frame update
    void Start()
    {
        if(spawnOnStart)
        {
            SpawnObject();
        }
        else
        {
            StartCoroutine("SpawnCountDown");
        }
    }

    private void Update()
    {
        if(!spawningItem && gameObject.transform.childCount == 0)
        {
            StartCoroutine("SpawnCountDown");
        }
    }

    private void SpawnObject()
    {
        Instantiate(spawnPrefab, gameObject.transform.position + spawnPosition, Quaternion.identity, gameObject.transform); //Might be better to disable and enable the object instead of destorying and instantiating.
        spawningItem = false;
    }

    IEnumerator SpawnCountDown()
    {
        spawningItem = true;
        float count = spawnWaitSeconds;
        while(count > 0) //I think this is off by one.
        {
            yield return new WaitForSeconds(1);
            count--;
        }
        SpawnObject();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(gameObject.transform.position, spawnerGizmoDimensions);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position + spawnPosition, itemGizmoRadius);
    }
}
