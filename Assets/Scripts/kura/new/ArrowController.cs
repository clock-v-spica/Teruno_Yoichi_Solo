using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private bool isLanched = false;
    [SerializeField] private bool isSet = false;
    [SerializeField] public BowManager _bowManager;
    [SerializeField] private float ForceCoefficient = 1f;
    Rigidbody rb;
    private float dis = 0;

    // Start is called before the first frame update
    void Start()
    {
        _bowManager = GameObject.Find("BowManager").GetComponent<BowManager>();
        rb = this.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSet)
        {
            dis = (_bowManager._LeftHand.transform.position - _bowManager._RightHand.transform.position).magnitude;
            _bowManager.BowDrawing(dis);
            Vector3 localPos = this.transform.localPosition;
            localPos.x = -dis;
            this.transform.localPosition = localPos;
        }
        
        if (OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger) && !isLanched)
        {
            isSet = false;
            isLanched = true;
            this.transform.parent = null;
            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(this.transform.right * ForceCoefficient * dis, ForceMode.Impulse);
            _bowManager.Reset();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bow" && !isLanched)
        {
            isSet = true;
            rb.constraints = RigidbodyConstraints.None;
            this.transform.parent = other.transform;
            this.transform.localPosition = other.transform.localPosition;
            this.transform.localRotation = Quaternion.identity;
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            rb.constraints = RigidbodyConstraints.FreezePositionZ;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }

        if (other.gameObject.tag == "Targets")
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
