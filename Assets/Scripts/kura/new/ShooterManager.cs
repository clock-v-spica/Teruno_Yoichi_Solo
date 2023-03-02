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

        public static bool Shottable;
        
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
            Debug.Log("col");
            if (other.tag == "ArrowBox")
            {
                if (!TerunoManager.IsHost)
                    return;

                if (!Shottable)
                    return;

                Debug.Log("if");

                if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
                {
                    Debug.Log("ar");
                    arrow = Network.NetworkUtility.Instantiate("Prefabs/Arrow_Bow", _RightHand.transform.position, _RightHand.transform.rotation * Quaternion.Euler(0f, 0.0f, 0f));
                    arrow.transform.parent = _RightHand.transform;
                    Shottable = false;
                }
            }
        }
    }
}
