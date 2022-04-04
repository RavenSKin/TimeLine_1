using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    float speed = 20;
    public int _damage = 10;
    public float direction;
    float LifeTime = 1f;
    
    void Start()
    {
        AudioSource _source = GameObject.Find("Audio_throw").GetComponent<AudioSource>();
        _source.Play();
    }

    // Update is called once per frame
    void Update()
    {
            transform.position += new Vector3(direction, 0, 0) * Time.deltaTime * speed;
        LifeTime -= Time.deltaTime;
        if (LifeTime < 0)
        {
            Destroy(gameObject);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
     
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemyhealth>().Health -= _damage;
            Debug.Log(collision.gameObject.GetComponent<Enemyhealth>().Health - _damage);
            Destroy(gameObject);
        }
    }
}
