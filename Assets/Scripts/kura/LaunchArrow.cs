using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchArrow : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject LeftHandPosition;
    public GameObject RightHandPosition;

    public Vector3 force;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // force = LeftHandPosition.transform.position - RightHandPosition.transform.position;
        rb.AddForce(force, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z >= 100)
        {
            Destroy(this);
        }
    }

}
