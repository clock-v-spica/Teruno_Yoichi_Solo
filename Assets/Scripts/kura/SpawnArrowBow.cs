using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArrowBow : MonoBehaviour
{
    public GameObject Arrow_bow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger))
        {
            Instantiate(Arrow_bow, this.transform.position, this.transform.rotation);
        }
    }
}
