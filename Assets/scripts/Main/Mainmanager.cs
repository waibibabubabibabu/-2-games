using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Mainmanager : MonoBehaviour
{
    public void playfootball()
    {
        SceneManager.LoadScene("playing football");
    }
    public void PickFruits()
    {
        SceneManager.LoadScene("Pick Fruits");
    }

}
