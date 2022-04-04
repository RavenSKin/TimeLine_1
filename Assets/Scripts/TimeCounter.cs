using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public Animator EndAnim;
    public GameObject TimerHandler;
    public float TimeSecond;
    public bool BattleGroundMode;
    public float regulatedTimeSecond;
    Health health;
    void Start()
    {
        health = GameObject.FindObjectOfType<Health>();
        if (BattleGroundMode)
        {
            TimeSecond = 0f;
        }
        TimerHandler.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!BattleGroundMode)
        {
            if (TimeSecond <= 0)
            {

                TimeSecond = 0f;
                EndCurrentScene();
            }
            else
            {

                TimeSecond -= Time.deltaTime;

            }
        }
        if (BattleGroundMode)
        {
            if (health.currentHealth > 0)
            {
                TimeSecond += Time.deltaTime;
            }
        }
        regulatedTimeSecond = Mathf.Floor(TimeSecond);

        TimerHandler.GetComponent<Text>().text = regulatedTimeSecond.ToString();
    }
    public void EndCurrentScene()
    {
        EndAnim.SetBool("Change", true);
    }
    public void EndByBot()
    {
        EndAnim.SetBool("Spotted", true);
    }
}
