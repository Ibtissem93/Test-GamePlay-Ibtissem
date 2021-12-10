using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleWall : MonoBehaviour
{
    [SerializeField] public Transform HeadOfPlayer;
    [SerializeField] public GameObject WallLipSprite;

    void OnTriggerEnter(Collider other)
    {

        if (other.transform.CompareTag("LipsFood"))
        {
            
            if (other.transform.name == "lipsPrincipal")
            {
                Debug.Log("Return Player to initial position");

            }
            else
            {
                HeadOfPlayer.position = HeadOfPlayer.position - new Vector3(0, 0, 1f);

                Destroy(other.gameObject);
                WallLipSprite.SetActive(true);
            }




        }



    }
}
