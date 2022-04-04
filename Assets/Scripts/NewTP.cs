using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTP : MonoBehaviour
{
    public GameObject EndPoint;
    GameObject character;
    public bool InsideCollider;
    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAA");
            character = GameObject.Find("Character");
            character.transform.position = EndPoint.transform.position;


        }

    }



}
