using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "LipsBody")
        {
           
            Transform snake = other.transform.parent;
            LipManager snakeComponent = snake.GetComponent<LipManager>();
            snakeComponent.DeleteLip(other.gameObject);
            Destroy(other.gameObject);

        }


    }
}
