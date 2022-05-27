using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitArrow : MonoBehaviour
{
    private Rigidbody _rb_arrow;

    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _rb_arrow = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Targets"))
        {
            _rb_arrow.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Targets"))
        {
            _rb_arrow.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

}
