using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject Menu;
    public GameObject[] Levels;
    public GameObject wrongScreen, rightScreen;
    public Text high_score_show;
    public Text score_show;
    public Text right_btn_txt;
    public Text wrong_btn_txt;

    int currentLevel = -1;
    int high_score = 0;
    int score = 0;

    private void Start()
    {
        Menu.SetActive(true);
        for (int i = 0; i < Levels.Length; i++) Levels[i].SetActive(false);
        score_show.gameObject.SetActive(false);
        high_score_show.text = "最高分數:" + high_score.ToString();
    }
    public void rightAnswer()
    {
        score++;
        score_txt_update();
        rightScreen.SetActive(true);
        if (currentLevel + 1 == Levels.Length)
        {
            right_btn_txt.text = "回到首頁";
        }
        else
        {
            right_btn_txt.text = "下一關";
        }
    }
    public void wrongAnswer()
    {
        wrongScreen.SetActive(true);
        if (currentLevel + 1 == Levels.Length) {
            wrong_btn_txt.text = "回到首頁";
        }
        else {
            wrong_btn_txt.text = "下一關";
        }
    }



    public void ResetGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }








    public void start_play() {
        currentLevel = 0;
        Menu.SetActive(false);
        Levels[currentLevel].SetActive(true);
        score_show.gameObject.SetActive(true);
    }
    public void finish_play() {
        Menu.SetActive(true);
        for (int i = 0; i < Levels.Length; i++) Levels[i].SetActive(false);
        if (score > high_score) high_score = score;
        high_score_show.text = "最高分數:" + high_score.ToString();
        score = 0;
        score_show.gameObject.SetActive(false);
    }
    public void next_level()
    {
        wrongScreen.SetActive(false);
        rightScreen.SetActive(false);
        if (currentLevel + 1 != Levels.Length)
        {
            Levels[currentLevel].SetActive(false);

            currentLevel++;
            Levels[currentLevel].SetActive(true);
        }
        else
        {
            finish_play();
        }
        score_txt_update();
    }

    void score_txt_update() {
        score_show.text = "Score:" + score.ToString();
    }


}
