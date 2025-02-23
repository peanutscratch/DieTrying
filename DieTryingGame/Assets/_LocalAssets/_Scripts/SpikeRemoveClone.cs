using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpikeRemoveClone : MonoBehaviour
{
    public DeadBodyManager deadBodyManager;
    public GameObject spikeModel;


    void Start()
    {
        deadBodyManager = FindObjectOfType<DeadBodyManager>(); 
    }
    void OnTriggerEnter2D(Collider2D other)
    {     
        Debug.Log("collided");
        if(other.gameObject.layer == 6) //if layer == "DeadBody"
        {
            
            
            Debug.Log("collided with dead body");
            if(other.gameObject != null && other.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                other.gameObject.transform.position = this.gameObject.transform.position;
                Rigidbody2D tempRigid = other.gameObject.GetComponent<Rigidbody2D>();
                tempRigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
                Collider2D tempCollider = other.gameObject.GetComponent<Collider2D>();
                tempCollider.enabled = false;
                spikeModel.SetActive(false);
            }

        }
    }

  


}
