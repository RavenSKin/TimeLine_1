using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Text _BonusHealth;
    public List<GameObject> hearth = new List<GameObject>();
    [Range(0, 6)] public int currentHealth;
    [HideInInspector] public int MaxHealth = 3;
    public PolygonCollider2D polygonCollider2D;
    public SpriteRenderer _mySprite;
    public int Difference;
    public List<GameObject> StartDisplay = new List<GameObject>();
    public List<GameObject> TextDisplay = new List<GameObject>();
    public Text Timer;
    ScorCounter _score;
    void Start()
    {

        _score = GameObject.FindObjectOfType<ScorCounter>();
        currentHealth += _score.CurrentHealthStore;
    }

    // Update is called once per frame
    void Update()
    {

        SetScore();
        Difference = MaxHealth - currentHealth;
        switch (currentHealth)
        {
            case 0:
                foreach (GameObject _h in hearth)
                {
                    _h.SetActive(false);
                }
                break;
            case 1:
                hearth[0].SetActive(true);
                hearth[1].SetActive(false);
                hearth[2].SetActive(false);
                break;

            case 2:
                hearth[0].SetActive(true);
                hearth[1].SetActive(true);
                hearth[2].SetActive(false);
                break;
            case 3:
                foreach (GameObject _h in hearth)
                {
                    _h.SetActive(true);
                }
                break;
        }
        if (currentHealth > 3)
        {
            _BonusHealth.text = (currentHealth - 3).ToString();
        }

        if (currentHealth <= 0)
        {
            GameObject[] enemyOnStage;
            enemyOnStage = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject _enemy in enemyOnStage)
            {
                _enemy.SetActive(false);
            }
            StartCoroutine(DisplayScoreBoard());
            Debug.Log("DEFAITE");
        }

    }
    IEnumerator DisplayScoreBoard()
    {
        Run run = GetComponent<Run>();
        run.enabled = false;
        Dash dash = GetComponent<Dash>();
        dash.enabled = false;
        Throw _throw = GetComponent<Throw>();
        _throw.enabled = false;
        _mySprite.enabled = false;
        polygonCollider2D.enabled = false;

        yield return new WaitForSeconds(0.1f);
        foreach (GameObject _start in StartDisplay)
        {
            _start.SetActive(true);
        }
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < TextDisplay.Count; i++)
        {
            TextDisplay[i].SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }

    }
    IEnumerator TakingDamage()
    {

        currentHealth -= 1;
        polygonCollider2D.enabled = false;
        yield return new WaitForSeconds(0.1f);
        _mySprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        _mySprite.enabled = true;
        yield return new WaitForSeconds(0.1f);
        _mySprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        _mySprite.enabled = true;
        yield return new WaitForSeconds(0.1f);
        _mySprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        _mySprite.enabled = true;
        polygonCollider2D.enabled = true;

    }
    public void Damaging()
    {
        StartCoroutine(TakingDamage());
    }
    void SetScore()
    {
        if (TextDisplay.Count>0)
        {
            TextDisplay[0].GetComponent<Text>().text = _score.EnemySlain.ToString();
            TextDisplay[1].GetComponent<Text>().text = (10 * _score.EnemySlain).ToString();
            TextDisplay[2].GetComponent<Text>().text = _score.score.ToString();
            TextDisplay[3].GetComponent<Text>().text = Timer.text;
            TextDisplay[4].GetComponent<Text>().text = Timer.text;
            TextDisplay[5].GetComponent<Text>().text = _score.Total.ToString();
        }

    }
}
