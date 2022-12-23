
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager2InOver : MonoBehaviour
{
    public GameObject scoretxt;
    int score;

    void RecieveData()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("data");
        //Transform[] transforms = Transform.Find(); 
        score = gameObjects[0].GetComponent<dataStorage>().GetFinalScore();

    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Pick Fruits");
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
