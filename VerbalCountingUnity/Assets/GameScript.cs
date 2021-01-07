using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    public int dif;
    public int theme;
    public string text;
    public GameObject textView;
    public float LevelTime;
    public GameObject hp;
    public Text roundText;
    public int round;
    public GameObject vremya;
    public GameObject pobeda;

    public int a;
    public int b;
    public int c;
    public int d;
    public int range;
    public string answerNum;

    public float Trueanswer;
    public int trueBut;
    public float trueAnswers;
    public Text trueAnswersText;

    public Text txt1;
    public Text txt2;
    public Text txt3;
    public Text txt4;

    public GameObject Verno;
    public GameObject NeVerno;

    public float repeat_time; /* Время в секундах */
    public float curr_time;
    public bool otvet;
    public float width;
    public int otsenka;
    public Text otsenkaText;
    public int mod5;
    public AchievementManager achievementManager;
    public void RoundSbros()
    {
        otsenka = 0;
        round = 0;
        trueAnswers = 0;
        dif = PlayerPrefs.GetInt("dif");
        theme = PlayerPrefs.GetInt("theme");
        pobeda.SetActive(false);
    }
    public void res ()
    {
        round += 1;
        roundText.text = round.ToString() + "/10";
        width = 1400f;
        otvet = false;
        Verno.SetActive(false);
        NeVerno.SetActive(false);
        answerNum = "";
        if (theme == 1)
            Theme1();
        if (theme == 2)
            Theme2();
        if (theme == 3)
            Theme3();
        if (theme == 4)
            Theme4();
        if (theme == 5)
            Theme5();
        curr_time = repeat_time;
        vremya.SetActive(false);

    }
    void Update()
    {
        hp.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
        textView.GetComponent<Text>().text = text;
        curr_time -= Time.deltaTime;
        if (curr_time <= 2 && otvet == false)
            vremya.SetActive(true);
        if (curr_time <= 0 && otvet == false)
            gameObject.SetActive(false);
        if (curr_time <= 0 && otvet == true)
        {
            if(round<=10)
                res();
            if (round >= 11)
            {
                trueAnswersText.text = "вы решили верно " + trueAnswers + "/10 заданий";
                if (trueAnswers < 5)
                    otsenka = 2;
                if (trueAnswers >= 5)
                    otsenka = 3;
                if (trueAnswers >= 8)
                    otsenka = 4;
                if (trueAnswers == 10)
                    otsenka = 5;
                otsenkaText.text = "ваша оценка: " + otsenka;
                if(otsenka == 5)
                {
                    PlayerPrefs.SetInt("otlichnik", + 1);
                    if(PlayerPrefs.GetInt("otlichnik") == 1)
                        achievementManager.UnlockAchievement(AchievementID.six);
                    if (PlayerPrefs.GetInt("otlichnik") == 10)
                        achievementManager.UnlockAchievement(AchievementID.seven);
                    if (PlayerPrefs.GetInt("otlichnik") == 100)
                        achievementManager.UnlockAchievement(AchievementID.eight);
                    if (theme == 5 && dif >= 2)
                        achievementManager.UnlockAchievement(AchievementID.thirteen);
                    if(dif == 1)
                        achievementManager.UnlockAchievement(AchievementID.one);
                    if (dif == 2)
                        achievementManager.UnlockAchievement(AchievementID.two);
                    if (dif == 3)
                        achievementManager.UnlockAchievement(AchievementID.three);
                    if (dif == 4)
                        achievementManager.UnlockAchievement(AchievementID.four);
                    if (dif == 5)
                        achievementManager.UnlockAchievement(AchievementID.five);
                }
                RoundSbros();
                pobeda.SetActive(true);
                
            }
        }

        width = 1400 / (repeat_time -2) * (curr_time - 2);
        if (answerNum == Trueanswer.ToString() && answerNum != "" && curr_time >= 2)
        {
            trueAnswers += 1;
            curr_time = 2;
            otvet = true;
            Verno.SetActive(true);
            answerNum = "";
        }
        if(answerNum != Trueanswer.ToString() && answerNum != "" && curr_time >= 2)
        {
            curr_time = 2;
            otvet = true;
            NeVerno.SetActive(true);
            answerNum = "";
        }
            
    }
    public void Theme1 ()
    {
        if (dif == 1)
        {
            range = 5;
            repeat_time = 12;
        }
        if (dif == 2)
        {
            range = 10;
            repeat_time = 7;
        }
        if (dif == 3)
        {
            range = 100;
            repeat_time = 7;
        }
        if (dif == 4)
        {
            range = 1000;
            repeat_time = 12;
        }
        if (dif == 5)
        {
            range = 10000;
            repeat_time = 16;
        }
        a = Random.Range(1, range);
        b = Random.Range(1, range);
        txt1.text = Random.Range(1, range * 2).ToString();
        txt2.text = Random.Range(1, range * 2).ToString();
        txt3.text = Random.Range(1, range * 2).ToString();
        txt4.text = Random.Range(1, range * 2).ToString();
        trueBut = Random.Range(1, 4);
        Trueanswer = a + b;
        while ((txt1.text == Trueanswer.ToString()) || (txt1.text == txt2.text) || (txt1.text == txt3.text) || (txt1.text == txt4.text))
        {
            txt1.text = Random.Range(1, range * 2).ToString();
        }
        while ((txt2.text == Trueanswer.ToString()) || (txt2.text == txt1.text) || (txt2.text == txt3.text) || (txt2.text == txt4.text))
        {
            txt2.text = Random.Range(1, range * 2).ToString();
        }
        while ((txt3.text == Trueanswer.ToString()) || (txt3.text == txt2.text) || (txt3.text == txt1.text) || (txt3.text == txt4.text))
        {
            txt3.text = Random.Range(1, range * 2).ToString();
        }
        while ((txt4.text == Trueanswer.ToString()) || (txt4.text == txt2.text) || (txt4.text == txt3.text) || (txt4.text == txt1.text))
        {
            txt4.text = Random.Range(1, range * 2).ToString();
        }
        if (trueBut == 1)
            txt1.text = (Trueanswer).ToString();
        if (trueBut == 2)
            txt2.text = (Trueanswer).ToString();
        if (trueBut == 3)
            txt3.text = (Trueanswer).ToString();
        if (trueBut == 4)
            txt4.text = (Trueanswer).ToString();
        text = a.ToString() + "+" + b.ToString();
    }
    public void Theme2()
    {
        if (dif == 1)
        {
            range = 10;
            repeat_time = 20;
        }
        if (dif == 2)
        {
            range = 20;
            repeat_time = 16;
        }
        if (dif == 3)
        {
            range = 50;
            repeat_time = 11;
        }
        if (dif == 4)
        {
            range = 100;
            repeat_time = 8;
        }
        if (dif == 5)
        {
            range = 1000;
            repeat_time = 10;
        }
        a = Random.Range(1, range);
        b = Random.Range(1, range);
        txt1.text = Random.Range(1, range).ToString();
        txt2.text = Random.Range(1, range).ToString();
        txt3.text = Random.Range(1, range).ToString();
        txt4.text = Random.Range(1, range).ToString();
        trueBut = Random.Range(1, 4);
        Trueanswer = a - b;
        while ((txt1.text == Trueanswer.ToString()) || (txt1.text == txt2.text) || (txt1.text == txt3.text) || (txt1.text == txt4.text))
        {
            txt1.text = Random.Range(1, range).ToString();
        }
        while ((txt2.text == Trueanswer.ToString()) || (txt2.text == txt1.text) || (txt2.text == txt3.text) || (txt2.text == txt4.text))
        {
            txt2.text = Random.Range(1, range).ToString();
        }
        while ((txt3.text == Trueanswer.ToString()) || (txt3.text == txt2.text) || (txt3.text == txt1.text) || (txt3.text == txt4.text))
        {
            txt3.text = Random.Range(1, range).ToString();
        }
        while ((txt4.text == Trueanswer.ToString()) || (txt4.text == txt2.text) || (txt4.text == txt3.text) || (txt4.text == txt1.text))
        {
            txt4.text = Random.Range(1, range).ToString();
        }
        if (trueBut == 1)
            txt1.text = (Trueanswer).ToString();
        if (trueBut == 2)
            txt2.text = (Trueanswer).ToString();
        if (trueBut == 3)
            txt3.text = (Trueanswer).ToString();
        if (trueBut == 4)
            txt4.text = (Trueanswer).ToString();
        text = a.ToString() + "-" + b.ToString();
    }
    public void Theme3()
    {
        if (dif == 1)
        {
            range = 5;
            repeat_time = 20;
        }
        if (dif == 2)
        {
            range = 10;
            repeat_time = 14;
        }
        if (dif == 3)
        {
            range = 10;
            repeat_time = 9;
        }
        if (dif == 4)
        {
            range = 100;
            repeat_time = 8;
        }
        if (dif == 5)
        {
            range = 100;
            repeat_time = 6;
        }
        a = Random.Range(1, range);
        b = Random.Range(1, range);
        txt1.text = Random.Range(1, range * range).ToString();
        txt2.text = Random.Range(1, range * range).ToString();
        txt3.text = Random.Range(1, range * range).ToString();
        txt4.text = Random.Range(1, range * range).ToString();
        trueBut = Random.Range(1, 4);
        Trueanswer = a * b;
        while ((txt1.text == Trueanswer.ToString()) || (txt1.text == txt2.text) || (txt1.text == txt3.text) || (txt1.text == txt4.text))
        {
            txt1.text = Random.Range(1, range * range).ToString();
        }
        while ((txt2.text == Trueanswer.ToString()) || (txt2.text == txt1.text) || (txt2.text == txt3.text) || (txt2.text == txt4.text))
        {
            txt2.text = Random.Range(1, range * range).ToString();
        }
        while ((txt3.text == Trueanswer.ToString()) || (txt3.text == txt2.text) || (txt3.text == txt1.text) || (txt3.text == txt4.text))
        {
            txt3.text = Random.Range(1, range * range).ToString();
        }
        while ((txt4.text == Trueanswer.ToString()) || (txt4.text == txt2.text) || (txt4.text == txt3.text) || (txt4.text == txt1.text))
        {
            txt4.text = Random.Range(1, range * range).ToString();
        }
        if (trueBut == 1)
            txt1.text = (Trueanswer).ToString();
        if (trueBut == 2)
            txt2.text = (Trueanswer).ToString();
        if (trueBut == 3)
            txt3.text = (Trueanswer).ToString();
        if (trueBut == 4)
            txt4.text = (Trueanswer).ToString();
        text = a.ToString() + "*" + b.ToString();
    }
    public void Theme4()
    {
        if (dif == 1)
        {
            range = 10;
            repeat_time = 12;
        }
        if (dif == 2)
        {
            range = 20;
            repeat_time = 7;
        }
        if (dif == 3)
        {
            range = 100;
            repeat_time = 8;
        }
        if (dif == 4)
        {
            range = 100;
            repeat_time = 6;
        }
        if (dif == 5)
        {
            range = 1000;
            repeat_time = 6;
        }
        a = Random.Range(1, range);
        b = Random.Range(1, range);
        while ((a % b) != 0 && b != 0 && a>=5 && b>=5)
        {
            a = Random.Range(1, range);
            b = Random.Range(1, range);
        }
        Trueanswer = a / b;
        txt1.text = Random.Range(1, range).ToString();
        txt2.text = Random.Range(1, range).ToString();
        txt3.text = Random.Range(1, range).ToString();
        txt4.text = Random.Range(1, range).ToString();
        trueBut = Random.Range(1, 4);
        Trueanswer = a / b;
        while ((txt1.text == Trueanswer.ToString()) || (txt1.text == txt2.text) || (txt1.text == txt3.text) || (txt1.text == txt4.text))
        {
            txt1.text = Random.Range(1, range).ToString();
        }
        while ((txt2.text == Trueanswer.ToString()) || (txt2.text == txt1.text) || (txt2.text == txt3.text) || (txt2.text == txt4.text))
        {
            txt2.text = Random.Range(1, range).ToString();
        }
        while ((txt3.text == Trueanswer.ToString()) || (txt3.text == txt2.text) || (txt3.text == txt1.text) || (txt3.text == txt4.text))
        {
            txt3.text = Random.Range(1, range).ToString();
        }
        while ((txt4.text == Trueanswer.ToString()) || (txt4.text == txt2.text) || (txt4.text == txt3.text) || (txt4.text == txt1.text))
        {
            txt4.text = Random.Range(1, range).ToString();
        }
        if (trueBut == 1)
            txt1.text = (Trueanswer).ToString();
        if (trueBut == 2)
            txt2.text = (Trueanswer).ToString();
        if (trueBut == 3)
            txt3.text = (Trueanswer).ToString();
        if (trueBut == 4)
            txt4.text = (Trueanswer).ToString();
        text = a.ToString() + ":" + b.ToString();
    }
    public void Theme5()
    {
        mod5 = Random.Range(1, 5);
        if (mod5 == 1)
            Theme1();
        if (mod5 == 2)
            Theme2();
        if (mod5 == 3)
            Theme3();
        if (mod5 == 4)
            Theme4();
        if (mod5 == 5)
            Theme5();
    }
    public void But1()
    {
        answerNum = txt1.text;
    }    
    public void But2()
    {
        answerNum = txt2.text;
    }   
    public void But3()
    {
        answerNum = txt3.text;
    }  
    public void But4()
    {
        answerNum = txt4.text;
    }
}
