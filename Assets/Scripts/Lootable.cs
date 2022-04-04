using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootable : MonoBehaviour
{
    public Transform SpawnPosition;
    public Sprite Open_Chest;
    bool PowerUpLooted;
    Lootlist lootlist;
    // Start is called before the first frame update
    void Start()
    {
        lootlist = GameObject.FindObjectOfType<Lootlist>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        gameObject.GetComponent<SpriteRenderer>().sprite = Open_Chest;       
        lootlist.PickALoot(SpawnPosition);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    
    }
}
