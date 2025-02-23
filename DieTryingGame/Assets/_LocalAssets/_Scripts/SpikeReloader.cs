using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeReloader : MonoBehaviour
{
    
    public GameObject spikeModel;

    void OnTriggerExit2D(Collider2D other)
    {     
        if(other.gameObject.layer == 6 && spikeModel.activeSelf == false) //if layer == "DeadBody"
        {
            Debug.Log("dead body exploded");
            if(other.gameObject.GetComponent<Rigidbody2D>() == null)
            {
                spikeModel.SetActive(true);
            }

        }
    }

}
