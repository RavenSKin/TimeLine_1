using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatcherBotBehavior : MonoBehaviour
{
    float speed = 5f;
    public Transform LeftPatroll;
    public Transform RightPatroll;
    Transform PointToReach;
    float direction;
    bool TakeANap;
    public float offsetRay = 5.6f;
    public LayerMask mask;
    public float NapTime;
    // Start is called before the first frame update
    void Start()
    {
        PointToReach = LeftPatroll;
    }

    // Update is called once per frame
    void Update()
    {
        Raycasting();
        Patroll();
    }
    void Raycasting()
    {
        if (PointToReach == LeftPatroll)
        {
            RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(transform.position.x + 0.5f, transform.position.y), Vector2.left, offsetRay, mask);
            if (hitLeft.collider != null)
            {
                AudioSource audioSource = GameObject.Find("Audio_Detected").GetComponent<AudioSource>();
                audioSource.Play();
                TimeCounter _time = GameObject.FindObjectOfType<TimeCounter>();
                _time.EndByBot();
                TakeANap = true;
            }
        }

        if (PointToReach == RightPatroll)
        {
            
            RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(transform.position.x + 0.5f, transform.position.y), Vector2.right, offsetRay, mask);
            if (hitRight.collider != null)
            {
                AudioSource audioSource = GameObject.Find("Audio_Detected").GetComponent<AudioSource>();
                audioSource.Play();
                TimeCounter _time = GameObject.FindObjectOfType<TimeCounter>();
                _time.EndByBot();
                TakeANap = true;
            }
        }
    }
    void Patroll()
    {
        if (!TakeANap)
        {
            transform.position += new Vector3(direction * (speed * Time.deltaTime), 0, 0);
        }


        if (PointToReach == LeftPatroll)
        {

            if (transform.position.x < LeftPatroll.position.x)
            {
                StartCoroutine(SleepySleepy());
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                PointToReach = RightPatroll;
            }
            direction = -1;
        }

        if (PointToReach == RightPatroll)
        {

            if (transform.position.x > RightPatroll.position.x)
            {
                StartCoroutine(SleepySleepy());
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                PointToReach = LeftPatroll;
            }
            direction = 1;
        }
    }
    IEnumerator SleepySleepy()
    {
        TakeANap = true;
        yield return new WaitForSeconds(NapTime);
        TakeANap = false;
    }

}
