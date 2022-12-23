using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruits : MonoBehaviour
{
    public Sprite[] sprites;
    
    public void ChangeSpirit(int number)
    {
        this.GetComponent<SpriteRenderer>().sprite = sprites[number];
    }
    /// <summary>
    /// 将本物品设置为是否课件
    /// </summary>
    /// <param name="val">bool变量</param>
    public void Set(bool val)
    {
        this.gameObject.SetActive(val);
    }

}
