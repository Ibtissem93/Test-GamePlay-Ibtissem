using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLipModel : MonoBehaviour
{
   
    int i = 4;

    void OnTriggerEnter(Collider other)
    {

        if (other.transform.CompareTag("LipsFood"))
        {
         
            ChangeLipsGateLight(other.gameObject);

        }
        
    }


    private void ChangeLipsGateLight(GameObject ChildGameObject2)
    {
        
            GameObject gameone = ChildGameObject2.transform.GetChild(4).gameObject;
            if (gameone.activeSelf)
            {

              gameone.SetActive(false);
           
              ChildGameObject2.transform.GetChild(5).gameObject.SetActive(true);
             
            }
            else 
            {

              GameObject gametwo = ChildGameObject2.transform.GetChild(5).gameObject;
                if (gametwo.activeSelf)
                {
                   gametwo.SetActive(false);
                   ChildGameObject2.transform.GetChild(6).gameObject.SetActive(true);
                }
                else
                {
                ChildGameObject2.transform.GetChild(6).gameObject.SetActive(false);
                GameObject gameThree = ChildGameObject2.transform.GetChild(7).gameObject;
                gameThree.SetActive(true);
                }
            }

         
    }
    
  
}
