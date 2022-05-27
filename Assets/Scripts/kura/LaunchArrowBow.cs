using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchArrowBow : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject LeftHandPosition;
    public GameObject RightHandPosition;

    private float force_abs_bow;
    private Vector3 force_bow;

    private bool is_launched = false;
    
    // Start is called before the first frame update
    void Start()
    {
        LeftHandPosition = GameObject.Find("LeftControllerAnchor");
        RightHandPosition = GameObject.Find("RightControllerAnchor");
        rb = GetComponent<Rigidbody>();
        force_abs_bow = (LeftHandPosition.transform.position - RightHandPosition.transform.position).magnitude * 50;
        force_bow = transform.forward * force_abs_bow;
        rb.AddForce(force_bow, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger) && !is_launched)
        {
            this.transform.position = RightHandPosition.transform.position;
            this.transform.rotation = RightHandPosition.transform.rotation;
        }

        if (OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger))
        {
            is_launched = true;
            force_abs_bow = (LeftHandPosition.transform.position - RightHandPosition.transform.position).magnitude * 30;
            force_bow = transform.forward * force_abs_bow;
            rb.AddForce(force_bow, ForceMode.Impulse);
        }
        
        */
        
        if (gameObject.transform.position.magnitude >= 100)
        {
            Destroy(gameObject);
        }
    }
}
