using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLipModel : MonoBehaviour
{
    public GameObject newLipPink;
    public GameObject newLipBlue;
   

    void OnTriggerEnter(Collider other)
    {

        if (other.transform.CompareTag("GateLight"))
        {
         
            ChangeLipsGateLight();

        }
        
        if (other.transform.CompareTag("Gate_P"))
        {
        
            ChangeLipsGateP();

        }
    }


    private void ChangeLipsGateLight()
    {

        GameObject ChildGameObject2 = transform.GetChild(4).gameObject;
        ChildGameObject2.SetActive(false);
        transform.GetChild(5).gameObject.SetActive(true);
      
    }
    
    private void ChangeLipsGateP()
    {

        GameObject ChildGameObject2 = transform.GetChild(4).gameObject;
        ChildGameObject2.SetActive(false);
        transform.GetChild(5).gameObject.SetActive(false);
        transform.GetChild(6).gameObject.SetActive(true);

    }

}
