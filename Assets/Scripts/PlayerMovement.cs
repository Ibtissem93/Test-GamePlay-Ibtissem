using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private bool playState;

    [SerializeField] private Joystick joystick;
    [SerializeField] private float sideForce;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float minX, maxX;
    [SerializeField] private GameObject Camera;
 
    [SerializeField] public Transform HeadOfPlayer;
    [SerializeField] public Transform ParentOfInstantiate;
   
    public Animator lipsRun;
    List<GameObject> goList;
    public GameObject newLip;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playState = true;
        goList = new List<GameObject>();


    }

    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z);
        if (playState == true)
        {
            rb.velocity = new Vector3(joystick.Horizontal * sideForce, rb.velocity.y, moveSpeed);
        }

        if (transform.localScale.y < 0.1f)
        {
         
            playState = false;
            Invoke(nameof(Restart), 3);
            
            transform.localScale = new Vector3(transform.localScale.x, 0.1f, transform.localScale.z);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag ("LipsFood"))
        {
            Destroy(other.gameObject);
            AddBody(other.gameObject);
     
        }

        if(other.transform.CompareTag("GateLight"))
        {
            Destroy(other.gameObject);
            ChangeLipsGateLight();
          
        }
    }

    private void ChangeLipsGateLight()
    {
        foreach (GameObject go in goList)
        {
            GameObject ChildGameObject1 = go.transform.GetChild(4).gameObject;
            ChildGameObject1.SetActive(false);
            Instantiate(newLip, ChildGameObject1.transform.position - new Vector3(0, 1.7f, 0), default, go.transform);


        }
        goList.Clear();
    }

    private void AddBody(GameObject objectToClone)
    {
      //  for (int i = 0; i < _parts.Count; i++)
     //   {
        GameObject NewObjAdded = Instantiate(objectToClone, HeadOfPlayer.position, HeadOfPlayer.rotation, ParentOfInstantiate);
      
        NewObjAdded.GetComponent<Animator>().enabled = true;
        NewObjAdded.GetComponent<Animator>().runtimeAnimatorController = lipsRun.runtimeAnimatorController;
        goList.Add(NewObjAdded);
        HeadOfPlayer.position = NewObjAdded.transform.position + new Vector3(0, 0, 1f);
       // }
       
  
    }

    void Restart()
    {
       // SceneManager.LoadScene("SampleScene");
    }
}