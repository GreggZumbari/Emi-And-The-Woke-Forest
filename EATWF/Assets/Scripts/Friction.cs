using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friction : MonoBehaviour
{
    public bool enableFriction;

    // Start is called before the first frame update
    void Start()
    {
        enableFriction = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Friction!
        if (enableFriction)
        {
            //Every frame, slightly reduce the x velocity
            GetComponent<Rigidbody>().velocity = new Vector3(0.96f * GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
        }
    }
}
