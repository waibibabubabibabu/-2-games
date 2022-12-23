using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dont : MonoBehaviour
{
    public static dont _dont { get; set; }
    private void Awake()
    {
        if(_dont!=null)
        {
            Destroy(gameObject);
        }
        else
        {
            _dont = this;
            Debug.Log("不要在加载场景时把这个删掉");
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
