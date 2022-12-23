using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Gamemamager : MonoBehaviour
{
    data data;
    public GameObject scoretxt;
    int score;

    void RecieveData()
    {
        GameObject []gameObjects=GameObject.FindGameObjectsWithTag("data");
        //Transform[] transforms = Transform.Find(); 
        score=gameObjects[0].GetComponent<data>().GetFinalScore();
        
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("playing football");
        //解决重复生成不可摧毁的问题
    }
    public void Over()
    {
        SceneManager.LoadScene("Main");
    }
    private void Start()
    {
        //接收分数
        RecieveData();
        //显示分数
        scoretxt.GetComponent<TextMeshProUGUI>().text = score.ToString() + "分";
        //Debug.Log("final data is:", scoretxt);
        //print(scoretxt);
    }
}
