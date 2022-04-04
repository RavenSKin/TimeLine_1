using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawning : MonoBehaviour
{
    public GameObject prefabToSpawn;
    float speed = 5f;
    public Transform LeftPatroll;
    public Transform RightPatroll;
    public Transform PointToReach;
    public float direction;
    Animator Cloud_Anim;
    float TimeBtwnSpawn = 5f;
    float currentTime;
    bool StartSpawning;
    public int EntityContained = 3;
    void Start()
    {
        
        LeftPatroll = GameObject.Find("Left").transform;
        RightPatroll = GameObject.Find("Right").transform;
        PointToReach = LeftPatroll;
        EntityContained = Random.Range(1, 10);
        currentTime = TimeBtwnSpawn;
        Cloud_Anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (currentTime <= 0 && EntityContained>0)
        {
            Cloud_Anim.Play("Cloud_Spawn");
        }
        if (currentTime > 0 )
        {
            
            Patroll();
            Cloud_Anim.Play("Default");
            currentTime -= Time.deltaTime;
        }
        if(EntityContained <= 0 )
        {
            Cloud_Anim.Play("Cloud_Destroy");
        }

    }
    public void KillCloudy()
    {
        Destroy(gameObject);
    }
    public void InstantiateTheBaby()
    {
        currentTime = TimeBtwnSpawn;
        GameObject lilOneTNT = GameObject.Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        EntityContained -= 1;
    }
    void Patroll()
    {
        transform.position += new Vector3(direction * (speed * Time.deltaTime), 0, 0);

        if (PointToReach == LeftPatroll)
        {
            
            if (transform.position.x < LeftPatroll.position.x)
            {
              
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                PointToReach = RightPatroll;
            }
            direction = -1;
        }

        if (PointToReach == RightPatroll)
        {

            if (transform.position.x > RightPatroll.position.x)
            {
                
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                PointToReach = LeftPatroll;
            }
            direction = 1;
        }
    }
}
