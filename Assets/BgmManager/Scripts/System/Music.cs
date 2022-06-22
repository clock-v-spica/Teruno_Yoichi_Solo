using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Music : MonoBehaviour {

    bool m_play = false;
    float m_volume = 0.0f;

    [SerializeField]
    AudioSource audioSource = null;

    MusicTable m_currentMusic;

    public bool IsSameAudioClip( MusicTable music )
    {
        if(m_currentMusic == null){
            return false;
        }
        return m_currentMusic.clip.name == music.clip.name;
    }

    public bool IsPlay()
    {
        return m_play;
    }

    public void SetAudioMixerGroup(AudioMixerGroup group)
    {
        audioSource.outputAudioMixerGroup = group;
    }

    public void SetVolume(float value)
    {
        m_volume = value;
        float volume = m_volume * m_currentMusic.volume;
        audioSource.volume = volume;
    }

    public void Play( MusicTable music )
    {
        m_currentMusic = music;
        m_play = true;
        audioSource.clip = music.clip;
        float volume = m_volume * m_currentMusic.volume;
        audioSource.volume = volume;
        audioSource.Play();
    }
    public void Stop()
    {
        m_play = false;
        audioSource.Stop();
    }

    private void Update()
    {
        if(m_play)
        {
            if( !audioSource.isPlaying )
            {
                audioSource.time = m_currentMusic.loopBeginTime;
                audioSource.Play();
            }
        }
    }

}
