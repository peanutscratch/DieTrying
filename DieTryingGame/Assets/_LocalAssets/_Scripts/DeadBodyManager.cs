using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeadBodyManager : MonoBehaviour
{
    public List<GameObject> deadBodies;
    public int bodyCountCap = 3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        deadBodies.RemoveAll( x => !x);
    }
}
