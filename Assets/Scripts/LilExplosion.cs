using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilExplosion : MonoBehaviour
{
    GameObject player;
    float direction;
    float speed;
    LayerMask mask;
    public float offsetRay;
   public  bool patrol = false;
    void Start()
    {
        mask = LayerMask.GetMask("Player");
        player = GameObject.FindGameObjectWithTag("Player");
        speed = Random.Range(5, 15);
    }


    void Update()
    {
        if (patrol)
        {
            MovementTillExplode();
        }
       
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            patrol = true;
        }
        if (collision.gameObject.tag == "Player") 
        {
            GameObject.FindObjectOfType<Health>().Damaging();
            Destroy(gameObject);
            Debug.Log("OUCH");
        }
    }
    void MovementTillExplode()
    {
        if (gameObject.transform.position.x < player.transform.position.x)
        {

            RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(transform.position.x + 0.5f, transform.position.y), Vector2.right, offsetRay, mask);
            if (hitRight.collider != null)
            {
                direction = 0;
                GameObject.FindObjectOfType<Health>().Damaging();
                Destroy(gameObject);
                Debug.Log("BOOM");

            }
            else
            {
                direction = 1;
            }

            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (gameObject.transform.position.x > player.transform.position.x)
        {
            RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(transform.position.x + 0.5f, transform.position.y), Vector2.left, offsetRay, mask);
            if (hitLeft.collider != null)
            {
                direction = 0;
                GameObject.FindObjectOfType<Health>().Damaging();
                Destroy(gameObject);
                Debug.Log("BOOM");
            }
            else
            {
                direction = -1;
            }


            GetComponent<SpriteRenderer>().flipX = false;
        }
        transform.position += new Vector3(direction * (speed * Time.deltaTime), 0, 0);
    }
    private void OnDestroy()
    {
        AudioSource _source = GameObject.Find("Audio_destroy").GetComponent<AudioSource>();
        _source.Play();
        GameObject.FindObjectOfType<ScorCounter>().EnemySlain++;
    }
}
