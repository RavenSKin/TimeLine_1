using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceLand : MonoBehaviour
{
    float ttw;
    public List<GameObject> prefabs = new List<GameObject>();
    public Transform spawnPoint;
    float currentTime;
    int cumulativeHealth;
    int InstanceCount;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



        if (currentTime <= 0)
        {
            int ObjectToPick = Random.Range(0, prefabs.Count);
            ttw = Random.Range(0.5f, 3);
            GameObject CurrentInstance = GameObject.Instantiate(prefabs[ObjectToPick], spawnPoint.position, Quaternion.identity);
            CurrentInstance.GetComponent<Enemyhealth>().Health += cumulativeHealth;
            InstanceCount++;
            if (InstanceCount >= 10)
            {
                cumulativeHealth += 10;
                InstanceCount = 0;
            }
            currentTime = ttw;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }

    }
}
