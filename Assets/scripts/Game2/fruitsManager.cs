using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruitsManager : MonoBehaviour
{
    public fruits[] fruits;
    float[] posY = new float[] { -1, 0.5f, 2.5f };
    public void Init()
    {
        Change(0);
    }
    public void Change(int num)
    {
        //变换整体的位置
        float posx = GamemnangerInMain2._gamemanager.posX[num];
        this.transform.position = new Vector2(posx, 0);
        //更换初始水果样式
        int count = 0;
        foreach (fruits fruit in fruits) { 
            fruit.ChangeSpirit(num);
            fruit.transform.position = new Vector2(posx, posY[count++]);
            fruit.Set(true);
        }
    }
   
}
