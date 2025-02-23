using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DeadBodyManager : MonoBehaviour
{
    public List<GameObject> deadBodies;
    public int bodyCountCap = 3;


    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject deadBody in deadBodies)
        {
            Destroy(deadBody.gameObject);
        }
        deadBodies.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
