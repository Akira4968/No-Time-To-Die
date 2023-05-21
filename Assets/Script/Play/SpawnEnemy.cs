using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] List<GameObject>  enemies = new List<GameObject>();
    [SerializeField] float time = 0;
    float queueTime =5;
    void Update()
    {
        if(time > queueTime)
        {
            Spawn();
            time = 0;
        }
        time += Time.deltaTime;
        
    }
    
    public void Spawn()
    {
        GameObject spawn = Instantiate(enemies[Random.Range(0, 3)]);
        spawn.transform.position = this.transform.position + new Vector3(Random.Range(30, -30), Random.Range(30, -30), 0);
    }
}
