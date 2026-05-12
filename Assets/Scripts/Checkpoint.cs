using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour, IInteractable
{
    public GameObject player;
    public Vector3 newPos;
    public void Interact()
    {
       newPos = player.transform.position;
        Debug.Log("Checkpoint reached!");
    }


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        newPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    
}



