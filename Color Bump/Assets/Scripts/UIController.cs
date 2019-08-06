using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public GameObject touchToStart;
    public GameObject gameOverPanel;
    public GameObject winPanel;

    public Image distanceBar;

    void Awake()
    {
        instance = this;
    }

    public void DestroyTouchToStart()
    {
        if (touchToStart != null)
            Destroy(touchToStart);
    }

    public void Win(){
        winPanel.SetActive(true);
    }

    public void GameOver(){
        gameOverPanel.SetActive(true);
   }

   public void fillImage(float value){
       distanceBar.fillAmount = value;
   }
}
