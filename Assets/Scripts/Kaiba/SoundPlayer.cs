using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField]
    AudioSource[] oceans;

    [SerializeField]
    AudioSource[] chorusSources;

    [SerializeField]
    AudioClip joyChorus;
    [SerializeField]
    AudioClip sadChorus;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MultiplyOceanVolume(float mul)
    {
        foreach (var item in oceans)
        {
            item.volume *= mul;
        }
    }

    public void PlayJoyChorus()
    {
        foreach (var item in chorusSources)
        {
            item.PlayOneShot(joyChorus);
        }
    }

    public void PlaySadChorus()
    {
        foreach (var item in chorusSources)
        {
            item.PlayOneShot(sadChorus);
        }
    }
}
