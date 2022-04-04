using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootlist : MonoBehaviour
{
    public List<GameObject> LootSprite = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PickALoot(Transform loot)
    {
        int indexToPick;
        indexToPick = Random.Range(0, LootSprite.Count);
        GameObject LootInstance = GameObject.Instantiate(LootSprite[indexToPick], loot.transform.position, Quaternion.identity);
        if(LootInstance.tag == "PowerUp")
        {
            LootSprite.RemoveAt(indexToPick);
        }
    }
}
