
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text goldText;
    [SerializeField] Text gameOverScoreText;
    [SerializeField] Text gameOverGoldText;
    private bool gameNotOver = true;

    private int goldPlus = 0;

    void Update()
    {
        if (gameNotOver)
        {
            ScoreCalculation((int)Camera.main.transform.position.y);
        }
       
    }

    void ScoreCalculation(int score)
    {
        scoreText.text = "Score:" + score;
    }
   public void GoldCalculation(int gold)
    {
        goldPlus+= gold;
      
        goldText.text = "x" + goldPlus;
    }
    public void GameOver()
    {
        gameNotOver = false;
        gameOverScoreText.text = scoreText.text;
        gameOverGoldText.text = goldText.text;
    }
   
}
