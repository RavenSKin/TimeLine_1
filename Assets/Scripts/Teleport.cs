using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject EndPoint;
    bool teleported;
    GameObject character;
    private void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {



        teleported = true;



    }
    private void Update()
    {
        if (teleported)
        {
            character.transform.position = EndPoint.transform.position;
            teleported = false;
        }
    }
}
