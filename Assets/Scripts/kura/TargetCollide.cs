using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollide : MonoBehaviour
{
    private AudioSource _audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Arrows"))
        {
            _audioSource.PlayOneShot(_audioSource.clip);
        }
    }

}
