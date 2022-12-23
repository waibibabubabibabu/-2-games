using UnityEngine;
using TMPro;
using TMPro.Examples;

public class football : MonoBehaviour
{
    public GameObject scoreText;
    Vector2 pos= new Vector2(-4.78f, -2.83f);
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger!");
        if (collision.tag == "ScoreTrigger1")
        {
            Gamemanager._gamemanager.score += 2;
        }
        else if (collision.tag == "ScoreTrigger2")
        {
            Gamemanager._gamemanager.score += 4;
        }
        else if (collision.tag == "ScoreTrigger3")
        {
            Gamemanager._gamemanager.score += 6;
        }
        else if (collision.tag == "GateTrigger")
        {
            Gamemanager._gamemanager.score += 8;
            Gamemanager._gamemanager.congrtulation.active=true;
        }
    }
    private void Update()
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = Gamemanager._gamemanager.score.ToString();
    }
    public void init()
    {
        this.GetComponent<Rigidbody2D>().position = pos;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
    }
}
