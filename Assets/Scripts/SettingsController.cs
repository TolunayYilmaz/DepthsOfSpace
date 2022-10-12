using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
   [SerializeField]private Button easy,medium,hard;
    

    public void RadioButton(string buttonName)
    {
        switch (buttonName)
        {
            case "easy":
                easy.interactable = false;
                medium.interactable = true;
                hard.interactable = true;
                break;
            case "medium":
                easy.interactable = true;
                medium.interactable = false;
                hard.interactable = true;
                break;
            case "hard":
                easy.interactable = true;
                medium.interactable = true;
                hard.interactable = false;
                break;
            default:
                break;
        }
       
    }

    public void BackMenu()
    {
        new BackMenu();
    }
}
