using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour
{
    public void OnExitGame()
    {
        //预处理
        Debug.Log("退出");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

#else   
         Application.Quit();
#endif
    }
}
