using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    [HideInInspector]
    public bool jump;
    public void OnPointerDown(PointerEventData eventData)
    {
       jump = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
      
        jump=false;
    }
}
