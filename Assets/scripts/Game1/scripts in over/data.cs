using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class data : MonoBehaviour
{
    public static data _data { get; set; }//单例
    int FinalScore;
    private void Awake()
    {
        if(_data!=null)
        {
            //解决重复保留的问题
            Destroy(gameObject);
        }
        else
        {
            _data = this;
            //不要在加载场景时把这个删掉
            Debug.Log("不要在加载场景时把这个删掉");
            //为什么已经不会删除却还是没在over找到
            GameObject.DontDestroyOnLoad(this);
        }
    }
    public void TransformScore(int score)
    {
       FinalScore = score;
        Debug.Log("最终分数是："+FinalScore);
    }
    public int GetFinalScore()
    {
        return FinalScore;
    }
}
