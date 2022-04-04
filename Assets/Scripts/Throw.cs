using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    Dash _dash;
    Run _run;
    ScorCounter _score;
    public Animator _animator;
    public GameObject Rock;
    public GameObject RightSpawn;
    public GameObject LeftSpawn;
    public GameObject DownLeft_Spawn;
    public GameObject DownRight_Spawn;
    public int damage;
    public bool RockThrow;
    // Start is called before the first frame update
    void Start()
    {
        _score = GameObject.FindObjectOfType<ScorCounter>();
        _dash = gameObject.GetComponent<Dash>();
        _run = gameObject.GetComponent<Run>();
        damage += _score.ThrowDamage;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.W) && _dash.StartDashing == false && _run._run.direction == 0)
        {
        
            _animator.SetBool("Throw", true);

           
        }
      
        

    }
    public void Throw_It()
    {
        if (!_run._crawl.Crawling)
        {
            if (!_run._get._mySprite.flipX)
            {
                GameObject rock_instance = GameObject.Instantiate(Rock, RightSpawn.transform.position, Quaternion.identity);
                rock_instance.GetComponent<Throwable>()._damage = damage;
                rock_instance.GetComponent<Throwable>().direction = 1;
                _animator.SetBool("Throw", false);
                RockThrow = false;


            }
            if (_run._get._mySprite.flipX)
            {

                GameObject rock_instance = GameObject.Instantiate(Rock, LeftSpawn.transform.position, Quaternion.identity);
                rock_instance.GetComponent<Throwable>()._damage = damage;
                rock_instance.GetComponent<Throwable>().direction = -1;
                _animator.SetBool("Throw", false);
                RockThrow = false;

            }
        }
        if(_run._crawl.Crawling)
        {
            if (!_run._get._mySprite.flipX)
            {
                GameObject rock_instance = GameObject.Instantiate(Rock, DownRight_Spawn.transform.position, Quaternion.identity);
                rock_instance.GetComponent<Throwable>()._damage = damage;
                rock_instance.GetComponent<Throwable>().direction = 1;
                _animator.SetBool("Throw", false);
                RockThrow = false;


            }
            if (_run._get._mySprite.flipX)
            {

                GameObject rock_instance = GameObject.Instantiate(Rock, DownLeft_Spawn.transform.position, Quaternion.identity);
                rock_instance.GetComponent<Throwable>()._damage = damage;
                rock_instance.GetComponent<Throwable>().direction = -1;
                _animator.SetBool("Throw", false);
                RockThrow = false;

            }
        }
        
    }
}
