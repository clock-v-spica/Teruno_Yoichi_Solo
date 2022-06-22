using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour
{
    [SerializeField]
    MusicManager BackGroundMusic = null;

    [SerializeField]
    MusicManager AmbientMusic = null;

    MusicTable m_defaultBgm;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SetDefaultBGM(MusicTable music)
    {
        m_defaultBgm = music;
        BackGroundMusic.ChangeMusic(music);
    }

    public void SetEventBgm(MusicTable music)
    {
        BackGroundMusic.ChangeMusic(music);
    }
    public void ChangeDefaultBgm()
    {
        if(m_defaultBgm != null){
            BackGroundMusic.ChangeMusic(m_defaultBgm);
        }
    }
    public void SetAmbient(MusicTable music)
    {
        AmbientMusic.ChangeMusic(music);
    }
}
