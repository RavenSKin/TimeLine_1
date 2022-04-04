using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public PolygonCollider2D pol_collider;
    public Animator _my_anim;
    public bool StartDashing;
    public float DashDistance;
    public float cooldown;
    float cooldownTime = 2f;
    public bool DashLeft;
    public bool DashRight;
    public bool CanDashLeft;
    public bool CanDashRight;
    public float offsetRay;
    LayerMask mask;
    Run _run;
    // Start is called before the first frame update
    void Start()
    {
        _run = gameObject.GetComponent<Run>();
        mask = LayerMask.GetMask("Obstacle");
        cooldown = cooldownTime;
        offsetRay = DashDistance + 0.5f;
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(transform.position.x - 0.5f, transform.position.y), Vector2.left, offsetRay, mask);

        if (hitLeft.collider != null)
        {
            Debug.Log("Peut pas dash à gauche");
            CanDashLeft = false;
        }
        else
        {
            CanDashLeft = true;
        }

        RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(transform.position.x + 0.5f, transform.position.y), Vector2.right, offsetRay, mask);

        if (hitRight.collider != null)
        {
            Debug.Log("Peut pas dash à droite");
            CanDashRight = false;
        }
        else
        {
            CanDashRight = true;
        }
        if (cooldown >= cooldownTime)
        {
            if (Input.GetKeyDown(KeyCode.Space)&&_run._run.direction == 0 && _run._crawl.Crawling == false)
            {
                _my_anim.SetBool("Running", false);
                _my_anim.SetBool("Dashing", true);
                
                StartDashing = true;
                
            }

        }
        if (StartDashing)
        {
            AudioSource audioSource = GameObject.Find("Audio_teleport").GetComponent<AudioSource>();
            audioSource.Play();
            StartCoroutine(DashCoroutine());
            DashLeft = false;
            DashRight = false;
            cooldown = 0;
            
            


        }
        if (!StartDashing)
        {
            pol_collider.enabled = true;
        }
        if (cooldown < cooldownTime)
        {
            cooldown += Time.deltaTime;
        }
    }

    IEnumerator DashCoroutine()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)&&CanDashLeft)
        {
            
            yield return new WaitForSeconds(0.2f);
            DashLeft = true;
            pol_collider.enabled = false;
            transform.position = new Vector3(transform.position.x - DashDistance, transform.position.y, transform.position.z);
            _my_anim.SetBool("Dashing", false);
            StartDashing = false;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)&&CanDashRight)
        {
            yield return new WaitForSeconds(0.2f);
            DashRight = true;
            pol_collider.enabled = false;
            transform.position = new Vector3(transform.position.x + DashDistance, transform.position.y, transform.position.z);
            _my_anim.SetBool("Dashing", false);
            StartDashing = false;
        }
        else
        {
            yield return new WaitForSeconds(1f);
            _my_anim.SetBool("Dashing", false);
            Debug.Log("Ah ! ");

            StartDashing = false;
        }
        if((Input.GetKeyDown(KeyCode.LeftArrow) && !CanDashLeft)||(Input.GetKeyDown(KeyCode.RightArrow) && CanDashRight))
        {
            Debug.Log("so ?");
            _my_anim.SetBool("Dashing", false);
            
            StartDashing = false;
        }

    }
}
