using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    bool isAlive = true;
    private GameObject creature;
    
    public float healthPoints = 100;
    private float strenght;
    private Rigidbody playerRigbody;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        playerRigbody = GetComponent<Rigidbody>();
        creature = GameObject.Find("Creature");
    }

    // Update is called once per frame
    void Update()
    {
        if (healthPoints <= 1 == isAlive)
        {
            
        }
        else
        {
            isAlive = false;
            Destroy(creature);
        }


    }
    private void OnDestroy()
    {
        
    }
}
