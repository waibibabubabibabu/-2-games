using System.IO.Ports;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamemnangerInMain2 : MonoBehaviour
{
    public static GamemnangerInMain2 _gamemanager;

    public dataTransform dt;
    public dataStorage dataStorage;
    public fruitsManager fruits;
    public playerInMain2 player;
    public GameObject scoreText;


    public  int gameCount=4;       //关卡个数
    public GameState gameStateInMain2;   //关卡状态
    public float[] posX=new float[] {-4.0f,5.0f,-2.0f,5.0f};   //随着关卡不同变换小孩,水果的水平位置，随机生成也可
    int nowGameCount = 0;   //目前的关卡
    public int score = 0;

    public int attention = 0;
    float timer;
    int Gamecount = 1;
    bool flag = false;//判断端口是否开启
    int waitingTime = 3;
    int jumpingTime = 5;

    private void Update()
    {
        if (gameStateInMain2 == GameState.waiting)
        {
            //计时
            timer += Time.deltaTime;
            //更新attention
            Getattention();
            if (timer > waitingTime)
            {
                Debug.Log("start!");
                Debug.Log("The final attention is:" + attention);
                timer = 0;//重置
                gameStateInMain2 = GameState.running;
                player.Pick();
            }
        }
        if(gameStateInMain2==GameState.running)
        {
            //计时，到了规定时间后跳跃停止
            timer += Time.deltaTime;
            //时刻更新分数板的分数
            scoreText.GetComponent<TextMeshProUGUI>().text = score.ToString();
            if(timer>jumpingTime)
            {
                Debug.Log("over");
                timer = 0;
                gameStateInMain2 = GameState.over;
                GameOver();
            }
        }
    }
    private void Start()
    {
        _gamemanager = this;
        GameInit();
        GameStart();
    }
    void GameInit()
    {
        gameStateInMain2 = GameState.waiting;
        fruits.Init();
        player.Init();
        score = 0;
    }
    void GameChangeState()
    {
        gameStateInMain2 = GameState.waiting;
        fruits.Change(nowGameCount);
        player.Change(nowGameCount);
    }
    void GameStart()
    {
        gameStateInMain2 = GameState.waiting;
    }
    void GameOver()
    {
        gameStateInMain2 = GameState.over;
        nowGameCount++;
        if(nowGameCount<gameCount)
        {
            GameChangeState();
        }
        else
        {
            Debug.Log("所有游戏结束");
            dataStorage.TransformScore(score);
            SceneManager.LoadScene("over2");
            //退出游戏
        }
    }
    /// <summary>
    /// 调用dt，从端口获取注意力
    /// </summary>
    public void Getattention()
    {
        if (!flag)
        {
            string[] portlist = dt.ScanPorts_API();
            if (portlist.Count() == 0)
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
        if (timer > waitingTime)
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
