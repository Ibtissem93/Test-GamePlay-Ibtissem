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
    [SerializeField] private GameObject winPanel, losePanel;
    [SerializeField] public Transform HeadOfPlayer;
    [SerializeField] public Transform ParentOfInstantiate;
    [SerializeField] private List<GameObject> _parts;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playState = true;

        _parts = new List<GameObject>();
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
            losePanel.SetActive(true);
        

            transform.localScale = new Vector3(transform.localScale.x, 0.1f, transform.localScale.z);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag ("LipsFood"))
        {
            Destroy(other.gameObject);
           // _parts.Add(other.gameObject);
            AddBody(other.gameObject);


        }
    }

    private void AddBody(GameObject objectToClone)
    {
      //  for (int i = 0; i < _parts.Count; i++)
     //   {
            GameObject NewObjAdded = Instantiate(objectToClone, HeadOfPlayer.position, default, ParentOfInstantiate);
        NewObjAdded.GetComponent<Animator>().Play("LipsRunAnim");
            HeadOfPlayer.position = NewObjAdded.transform.position + new Vector3(0, 0, 2);
       // }
       
  
    }

    void Restart()
    {
       // SceneManager.LoadScene("SampleScene");
    }
}