using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInMain2 : MonoBehaviour
{
    public Sprite[] sprite;
    public fruitsManager fruitsManager;
    float posY = -3.49f; //人物对应的位置
    public void Init()
    {
        Change(0);
    }
    /// <summary>
    /// 改变状态
    /// </summary>
    /// <param name="num">关卡</param>
    public void Change(int num)
    {
        ChangePos(num);
        ChangeSpirit(num);
    }
    public void ChangeSpirit(int num)
    {
        this.GetComponent<SpriteRenderer>().sprite = sprite[num];
    }
    public void ChangePos(int num)
    {
        float posx = GamemnangerInMain2._gamemanager.posX[num];
        this.transform.position = new Vector2(posx, posY);
    }
    public void Pick()
    {
        int attention = GamemnangerInMain2._gamemanager.attention;
        Vector2 jumpForce = new Vector2(0, attention * 7);
        this.GetComponent<Rigidbody2D>().AddForce(jumpForce);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger!");
        if (collision.name == "low") { 
            GamemnangerInMain2._gamemanager.score += 5;
            fruitsManager.fruits[0].Set(false);
        }
        else if (collision.name == "middle")
        {
            GamemnangerInMain2._gamemanager.score += 10;
            fruitsManager.fruits[1].Set(false);
        }
        else
        {
            GamemnangerInMain2._gamemanager.score += 10;
            fruitsManager.fruits[2].Set(false);
        }
    }
}
