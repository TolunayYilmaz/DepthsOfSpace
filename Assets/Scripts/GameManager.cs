using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]GameObject gameOverPanel;
    [SerializeField] GameObject joystickButton;
    [SerializeField] GameObject jumpButton;
    [SerializeField] GameObject menubutton;
    [SerializeField] GameObject signboard;
    [SerializeField] GameObject jumpSlider;

    private void Start()
    {
        gameOverPanel.SetActive(false);
        UiOpen();
    }
    public void GameOver()
    {
        Debug.Log("Game Over");
        UiClose();
      gameOverPanel.SetActive(true);
       FindObjectOfType<Score>().GameOver();
    }
    public void ReturnMainmenu()
    {
        new BackMenu();
    }
    public void UiOpen()
    {
        joystickButton.SetActive(true);
        jumpButton.SetActive(true);
        menubutton.SetActive(true);
        signboard.SetActive(true);
        jumpSlider.SetActive(true);
      
    }
    public void UiClose()
    {
        joystickButton.SetActive(false);
        jumpButton.SetActive(false);
        menubutton.SetActive(false);
        signboard.SetActive(false);
        jumpSlider.SetActive(false);
    }
    public void RestartGame()
    {
        new BackMenu().LoadRestartGame();
    }
}
