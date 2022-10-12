using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePool : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject planePrafab;
    [SerializeField] GameObject deadlyPlanePrafab;
    [SerializeField] GameObject playerPrafab;
    List<GameObject> planesList= new List<GameObject> ();
    Vector2 planePos;
    Vector2 playerPos;
    void Start()
    {
        SpawnPlane();
    }

    // Update is called once per frame
    void Update()
    {

        if (planesList[planesList.Count - 1].transform.position.y < Camera.main.transform.position.y+ ScreenCalculator.instance.Height)
        {
            Debug.Log("Yeni plane");
            PlanePlacement();
        }
   
    }
    void SpawnPlane()
    {
         planePos = new Vector2(0, 0);
         playerPos= new Vector2(0, 1f);
        GameObject planed= Instantiate (planePrafab, planePos, Quaternion.identity);
        GameObject player=  Instantiate (playerPrafab, playerPos, Quaternion.identity);
        player.transform.parent = planed.transform;
        planesList.Add (planed);
        AfterPosition();
        for (int i = 0; i < 8; i++)
        {
            GameObject plane = Instantiate(planePrafab, planePos, Quaternion.identity);
            plane.GetComponent<PlaneMove>().PlaneMovement = true;
            if(i % 2 == 0)
            {
                plane.GetComponent<Gold>().goldActive();
            }
            planesList.Add(plane);
            AfterPosition();
        }
        
        GameObject deadlyPlane= Instantiate(deadlyPlanePrafab, planePos, Quaternion.identity);
        deadlyPlane.GetComponent<DeadlyPlane>().PlaneMovement = true; 
        planesList.Add(deadlyPlane);
        AfterPosition ();
    }
    void AfterPosition()
    {
        planePos.y += 3f;
        float randompos = Random.Range(0, 1f);
        if(randompos < 0.5f)
        {
            planePos.x = -ScreenCalculator.instance.Widht / 2 ;
        }
        else
        {
            planePos.x = ScreenCalculator.instance.Widht / 2 ;
        }
        
    }
    void PlanePlacement()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject temp;
            temp = planesList[i + 5];
            planesList[i + 5] = planesList[i];
            planesList[i] = temp;
            planesList[i + 5].transform.position = planePos;
            if(planesList[i + 5].CompareTag("Plane"))
            {
                 planesList[i + 5].GetComponent<Gold>().goldNotActive();
                float randomGold = Random.Range(0, 1f);
                if (randomGold > 0.5f)
                {
                    planesList[i + 5].GetComponent<Gold>().goldActive();
                }
            }
            AfterPosition();
        }
       
    }
}
