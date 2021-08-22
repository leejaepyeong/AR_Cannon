using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    bool isLevel = false;

    public LevelData levelData;

    public void startBtn()
    {
        if(isLevel)
        SceneManager.LoadScene(1);
    }

    public void LevelBtn(int num)
    {
        isLevel = true;

        levelData.level = num;
    }
}
