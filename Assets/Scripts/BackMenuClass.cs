
using UnityEngine.SceneManagement;
public class BackMenu
{/// <summary>
 /// It provides access to the MainMenu.
 /// </summary>
    public BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void LoadRestartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
}