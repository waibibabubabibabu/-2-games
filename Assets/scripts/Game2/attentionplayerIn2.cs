using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attentionplayerIn2 : MonoBehaviour
{
    public Image fill;//显示进度条的面板
    public Slider slider;//滑动条组件
    public GameObject footballOnSlider;//滑动条上的足球

    int attention;//注意力
    bool isPlaying = false;//判断目前是否是在变化中
    float timer;//计时器
    float speed = 2;//进度条滑动的速度
    int eps = 1;//控制进度条不来回滑动

    private void Update()
    {
        if (GamemnangerInMain2._gamemanager.gameStateInMain2 == GameState.waiting)
        {
            if (isPlaying == false)
            {
                attention = GamemnangerInMain2._gamemanager.attention;
                isPlaying = true;
            }
            else
            {
                timer += Time.deltaTime;
                if (Mathf.Abs(slider.value - attention) < eps) { isPlaying = false; timer = 0; }
                if (slider.value < attention)
                {
                    slider.value += timer * speed;
                    //Debug.Log(slider.value);
                    //fill.fillAmount += timer*speed;
                    getColor(slider.value);
                }
                else
                {
                    slider.value -= timer * speed;
                    //fill.fillAmount -= timer*speed;
                    getColor(slider.value);
                }
            }
        }
    }
    private void Start()
    {
        slider.maxValue = 100;

    }
    void getColor(float value)
    {
        //Debug.Log("change color！");
        if (value <= 33) { fill.color = Color.Lerp(Color.green, Color.white, (33.0f - value) / 33.0f); }
        else if (value <= 66) { fill.color = Color.Lerp(Color.yellow, Color.green, (66.0f - value) / 33.0f); }
        else { fill.color = Color.Lerp(Color.red, Color.yellow, (100.0f - value) / 33.0f); }
    }
}
