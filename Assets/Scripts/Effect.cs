using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public enum EffectType { DamageUp, HealthUp, Fury, ScoreUp }
    public EffectType _effect;
     AudioSource _Source;

    private void Start()
    {
        _Source = GameObject.Find("Audio_Coin").GetComponent<AudioSource>();
    }
    void UseEffect()
    {
        switch (_effect)
        {
            case EffectType.DamageUp:
                GameObject.FindObjectOfType<Throw>().damage += 10;
                GameObject.FindObjectOfType<ScorCounter>().ThrowDamage += 10;
                Debug.Log("DamageUp");
                break;
            case EffectType.HealthUp:

                GameObject.FindObjectOfType<Health>().currentHealth++;
                GameObject.FindObjectOfType<ScorCounter>().CurrentHealthStore++;
                Debug.Log("HealthUp");

                break;
            case EffectType.ScoreUp:
                GameObject.FindObjectOfType<ScorCounter>().score += 25;
                Debug.Log("ScoreUp");
                break;
            case EffectType.Fury:
                Debug.Log("Fury");
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _Source.Play();
            UseEffect();
            Destroy(gameObject);

        }

    }
}
