using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public Text scoreObject;

    public Text boomCount;

    [Header("WinPanel")]
    public GameObject winPanel;
    public Text WinTxt;
    public Text WinScoreTxt;

    [Header("EndPanel")]
    public GameObject EndPanel;
    public Text EndTxt;
    public Text EndScoreTxt;


    public LevelData levelData;
    public int GameLevel;

    private void Start()
    {
        if (instance == null)
            instance = this;

        GameLevel = levelData.level;

        if (GameLevel == 3)
            GameTime = 120f;
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
        ScoreTxt.text = "Score : " + Score.ToString();
    }

    public void HitOn(int _num)
    {
        
        if (_num == 1)
        {
            scoreObject.text = "+100";
            ScoreUp(100);
        }
        else
        {
            scoreObject.text = "Miss";
        }

        StartCoroutine(TextAnim());

        
    }

    IEnumerator TextAnim()
    {
        scoreObject.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        scoreObject.gameObject.SetActive(false);
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
