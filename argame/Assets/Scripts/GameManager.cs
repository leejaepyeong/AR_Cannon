using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int Score = 0;
    public float maxHp = 100f;
    public float currentHp = 100f;

    public float GameTime = 60f;

    public bool isEnd = false;

    [Header("GamePanel")]
    public GameObject GamePanel;
    public Text TimeTxt;
    public Text ScoreTxt;
    public Image HpBar;

    public TextMeshPro scoreObjects;
    public GameObject scoreSpawn;

    public Text boomCount;

    [Header("WinPanel")]
    public GameObject winPanel;
    public Text WinTxt;
    public Text WinScoreTxt;

    [Header("EndPanel")]
    public GameObject EndPanel;
    public Text EndTxt;
    public Text EndScoreTxt;


    private void Start()
    {
        if (instance == null)
            instance = this;
    }



    private void Update()
    {
        if(!isEnd)
        {
            GameTime -= Time.deltaTime;
            TimeTxt.text = ((int)GameTime).ToString();

            if(GameTime <= 0)
            {
                isEnd = true;
                Victory();
            }
        }

    }

    public void Damage(float _damage)
    {
        currentHp -= _damage;
        HpBar.fillAmount = currentHp / maxHp;

        if(currentHp <= 0 )
        {
            isEnd = true;
            EndPanel.SetActive(true);
        }

    }

    public void ScoreUp(int _score)
    {
        Score += _score;
        ScoreTxt.text = Score.ToString();
    }

    public void HitOn(int _num)
    {
        TextMeshPro scoreObject = Instantiate(scoreObjects, scoreSpawn.transform.position, scoreSpawn.transform.rotation);

        if (_num == 1)
        {
            scoreObject.text = "+100";
            ScoreUp(100);
        }
        else
        {
            scoreObject.text = "Miss";
        }

        Destroy(scoreObject, 0.85f);

        
    }

    public void Victory()
    {
        winPanel.SetActive(true);
    }

    public void ResetBtn()
    {
        SceneManager.LoadScene(0);
    }


}
