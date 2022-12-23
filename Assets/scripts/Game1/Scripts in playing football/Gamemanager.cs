using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    ready=0,
    waiting=1,//进入游戏开始蓄力
    start=2,//人物做动作，踢出球
    running=3,
    over=4//球停止滚动
}
public class Gamemanager : MonoBehaviour
{
    public static Gamemanager _gamemanager;

    public GameState gameState;
    public GameObject congrtulation;
    public football  football;
    public player player;
    public dataTransform dt;
    public  int MaxGamecount;//一共玩多少次
    public int waitingTime = 3;//要等待多长时间

    public int score = 0;
    public int attention = 0;
    float timer;
    int Gamecount = 1;
    bool flag = false;//判断端口是否开启

    // Start is called before the first frame update
    void Start()
    {
        _gamemanager = this;
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameState==GameState.waiting)
        {
            //计时
            timer += Time.deltaTime;
            //更新attention
            Getattention();
            if (timer > waitingTime)
            {
                Debug.Log("start kick!");
                Debug.Log("The final attention is:" +attention);
                timer = 0;//重置
                gameState = GameState.start;
            }
        }
        if(gameState==GameState.running)
        {
            timer += Time.deltaTime;
            if(timer>10)
            {
                Debug.Log("The football has stoped!");
                timer = 0;
                gameState = GameState.over;
            }
        }
        if(gameState==GameState.over)
        {
            if(Gamecount<MaxGamecount)
            {
                Gamecount++;
                Upload(score);
            }
            else
            {
                GameOver();
            }
        }
    }
    void Upload(int score)
    {
        //上传分数作为参考
        Init();
    }
    void  Init()
    {
        player.init();
        football.init();
        //score = 0;
        gameState = GameState.waiting;
        congrtulation.SetActive(false);
    }
    void GameOver()
    {
        //上传分数进行参考
        data._data.TransformScore(score);
        SceneManager.LoadScene("over");
    }

    public void Getattention()
    {
        if(!flag)
        {
            string[] portlist = dt.ScanPorts_API();
            if(portlist.Count()==0)
            {
                Debug.Log("无可用端口!");
                return;
            }
            //扫描？
            dt.OpenSerialPort(portlist[0], 115200, Parity.None, 8, StopBits.One);//打开端口
            Debug.Log("端口已经打开,端口名是");
            Debug.Log(portlist[0]);
            flag = true;
        }
        attention = dt.attention;
        //Debug.Log(dt.attention);
        if (timer>waitingTime)
        {
            Debug.Log("端口已经关闭");
            dt.CloseSerialPort();
            flag = false;
            //初始化dt内部的attention
            dt.attention = 0;
            dt.count = 0;

        }

    }
}
