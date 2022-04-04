using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorCounter : MonoBehaviour
{
    public int score;
    public int CurrentHealthStore;
    public int ThrowDamage;
    public int EnemySlain;
    public int Total;
    public int _time;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
       _time = Mathf.FloorToInt(GameObject.FindObjectOfType<TimeCounter>().regulatedTimeSecond);
        Total = (EnemySlain * 10) + score + _time ;
    }


}
