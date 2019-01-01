using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Sprite[] lives;
    public Image livesImage;

    public GameObject startScreen;
    public Text scoreText;
    public int score;
    
   

   

	public void UpdateLives (int currentLives)
    {
        livesImage.sprite = lives[currentLives];
	}

    public void UpdateScore()
    {
        score =score + 1;

        scoreText.text = "Score :" + score;
       
        
    }

    public void ShowStartScreen()
    {
        startScreen.SetActive(true);
        score = -1;

    }

    public void HideStartScreen()
    {
        startScreen.SetActive(false);
        

    }
        
}
