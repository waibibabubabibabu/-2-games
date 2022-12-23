
using UnityEngine;
using UnityEngine.UI;

public class pauseAndContinue : MonoBehaviour
{
    bool isPause = false;
    public Sprite pause;
    public Sprite start;
    public void PauseAndContinue()
    {
        if (isPause == false)
        {
            this.GetComponent<Image>().sprite = start;
            isPause = true;
            Time.timeScale = 0;
        }
        else
        {
            this.GetComponent<Image>().sprite = pause;
            isPause = false;
            Time.timeScale = 1.0f;
        }
    }
}

