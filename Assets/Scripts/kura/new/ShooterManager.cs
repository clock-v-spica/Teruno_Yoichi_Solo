using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Kaiba.Teruno_System
{
    public class ShooterManager : MonoBehaviour
    {
        [SerializeField] public GameObject _LeftHand;
        [SerializeField] public GameObject _RightHand;

        private GameObject arrow;
        
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "ArrowBox")
            {
                if (!TerunoManager.IsHost)
                    return;

                if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
                {
                    arrow = Network.NetworkUtility.Instantiate("Prefabs/Arrow_Bow", _RightHand.transform.position, _RightHand.transform.rotation * Quaternion.Euler(0f, 0.0f, 0f));
                    arrow.transform.parent = _RightHand.transform;
                }
            }
        }
    }
}
