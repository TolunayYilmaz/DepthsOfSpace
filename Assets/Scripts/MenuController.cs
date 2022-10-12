
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController:MonoBehaviour
{
    [SerializeField] Sprite[] musicSprite;
    [SerializeField] Button musicButton;
    bool musicEnabled = true;

    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void HighScore()
    {
        SceneManager.LoadScene("Highscore");
    }

    public void MusicPlayandPause()
    {
        if (musicEnabled)
        {
            musicButton.image.sprite = musicSprite[0];
            musicEnabled = false;
        }
        else
        {
            musicButton.image.sprite = musicSprite[1];
            musicEnabled = true;
        }

    }
}
