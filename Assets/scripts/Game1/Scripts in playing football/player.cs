using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player : MonoBehaviour
{
    public Sprite[] Player;

    float timer=0;
    public int speed = 1;

    public GameObject football;
    public int attention;//注意力，后期需要从gamemanager进行计算
    private void FixedUpdate()
    {
        //需判断是否开始踢球
        if (Gamemanager._gamemanager.gameState == GameState.start)
        {
            timer += speed * Time.deltaTime;
            int index = (int)timer;
            if (index > 2)
            {
                Debug.Log("Change state!");
                //踢足球
                attention = Gamemanager._gamemanager.attention;
                Vector2 force = new Vector2(attention * 5, attention * 3);
                Vector2 pos = -football.GetComponent<Rigidbody2D>().position-new Vector2(0.8f,0.6f);
                
                football.GetComponent<Rigidbody2D>().AddForceAtPosition(force,pos);
                //踢完
                Gamemanager._gamemanager.gameState = GameState.running;
            }
            else this.GetComponent<SpriteRenderer>().sprite = Player[index];
        }
    }
    public void init()
    {
        this.GetComponent<SpriteRenderer>().sprite = Player[0];
        timer = 0;
    }
}
