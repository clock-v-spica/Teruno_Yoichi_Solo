using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArrow : MonoBehaviour
{
    public GameObject Arrow;
    private Vector3 mousePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            Instantiate(Arrow, this.transform.position, this.transform.rotation);
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(Arrow, this.transform.position, this.transform.rotation);
        }
    }
}
