using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Run : MonoBehaviour
{
    [Serializable]
    public struct Getter
    {
        public GameObject Go_Collider;
        public GameObject Go_Sprite;
        public Animator _myAnim;
        public SpriteRenderer _mySprite;
        public Rigidbody2D _rb2d;
    }
    [Serializable]
    public struct RunVariable
    {
        public float direction;
        public float MinSpeed;
        public float speed;
        public float MaxSpeed;
    }
    [Serializable]
    public struct RaycastVariable
    {
        public float offsetRay;
        public float offsetRayJump;
        public bool CanRunRight;
        public bool CanRunLeft;
        public LayerMask mask;
    }

    [HideInInspector] public bool CanRun = true;
    [Serializable]
    public struct CrawlVariable
    {
        public bool Crawling;
    }
    [Serializable]
    public struct FallDown
    {
        public float startSpeed;
        public float MaxSpeed;
        public float fallSpeed;
    }
    public Getter _get;
    public RunVariable _run;
    public RaycastVariable _raycast;
    public CrawlVariable _crawl;
    public FallDown _fall;
    public GameObject OtherPosition;
    void Start()
    {
        _raycast.mask = LayerMask.GetMask("Obstacle");
        _run.speed = _run.MinSpeed;
    }


    void Update()
    {
        Fall();
        Running_Function();
        
        FixCollision();
        
        if (Input.GetKeyDown(KeyCode.DownArrow) && _run.direction == 0 && gameObject.GetComponent<Dash>().StartDashing == false)
        {
            _get._myAnim.SetBool("Crawl", true);
            _crawl.Crawling = true;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            _get._myAnim.SetBool("Crawl", false);
            _crawl.Crawling = false;
        }
        if (gameObject.GetComponent<Dash>().StartDashing)
        {
            _run.speed = 0f;
        }




    }

    void Running_Function()
    {
        _run.direction = Input.GetAxis("Horizontal");
        transform.position += new Vector3(_run.direction, 0, 0) * Time.deltaTime * _run.speed;
        if (gameObject.GetComponent<Dash>().StartDashing)
        {
            CanRun = false;
        }
        else
        {
            CanRun = true;
        }
        if (CanRun)
        {
            #region Run_Stuff

            if (_run.direction < 0)
            {
                if (_raycast.CanRunLeft)
                {
                    _run.speed += _run.speed * Time.deltaTime * 2;
                }
                else
                {
                    _run.speed = 0;
                }

                _get._mySprite.flipX = true;
                _get.Go_Collider.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            if (_run.direction > 0)
            {
                if (_raycast.CanRunRight)
                {
                    _run.speed += _run.speed * Time.deltaTime * 2;
                }
                else
                {
                    _run.speed = 0;
                }
                _get.Go_Collider.transform.rotation = Quaternion.Euler(0, 0, 0);
                _get._mySprite.flipX = false;
            }
            if (_run.direction != 0 && CanRun)
            {
                _get._myAnim.SetBool("Moving", true);

            }
            else
            {
                _run.speed = _run.MinSpeed;
                _get._myAnim.SetBool("Moving", false);
                _get._myAnim.Play("Default");
                // anim d'IDLE
            }
            if (_run.speed >= _run.MaxSpeed)
            {
                _run.speed = _run.MaxSpeed;
            }
            #endregion
        }


    }


    void Fall()
    {
        RaycastHit2D hitdown = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, _raycast.offsetRayJump, _raycast.mask);

        if (hitdown.collider != null)
        {
            _fall.fallSpeed = _fall.startSpeed;
        }
        else
        {
            if (_fall.fallSpeed < _fall.MaxSpeed)
            {
                _fall.fallSpeed += Time.deltaTime;
            }
            transform.position -= new Vector3(0, _fall.fallSpeed, 0)*(6*Time.deltaTime);
        }
    }


    void FixCollision()
    {
        Vector2 rightRay = new Vector2(transform.position.x + _raycast.offsetRay, transform.position.y);
        Vector2 leftRay = new Vector2(transform.position.x - _raycast.offsetRay, transform.position.y);

        _get.Go_Collider.transform.position = transform.position;
        _get.Go_Sprite.transform.position = transform.position;

        RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(transform.position.x - 0.5f, transform.position.y), Vector2.left, _raycast.offsetRay, _raycast.mask);

        if (hitLeft.collider != null)
        {

            _raycast.CanRunLeft = false;
        }
        else
        {
            _raycast.CanRunLeft = true;
        }

        RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(transform.position.x + 0.5f, transform.position.y), Vector2.right, _raycast.offsetRay, _raycast.mask);

        if (hitRight.collider != null)
        {

            _raycast.CanRunRight = false;
        }
        else
        {
            _raycast.CanRunRight = true;
        }
    }

}
