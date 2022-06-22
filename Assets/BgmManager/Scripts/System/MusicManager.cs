using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public AudioMixerGroup MixerGroup;
    public Music musicPrefab;
    public float FadeTime = 0.5f;

    Music m_music1, m_music2;
    MusicTable[] m_request_musics = null;
    int m_request_num=0;
    bool m_fade = false;
    float m_fade_count = 0.0f;

    const int RequestMaxNum = 8;

    protected void Awake()
    {
        m_request_musics = new MusicTable[RequestMaxNum];

        m_music1 = Instantiate(musicPrefab) as Music;
        DontDestroyOnLoad(m_music1);
        m_music1.SetAudioMixerGroup(MixerGroup);

        m_music2 = Instantiate(musicPrefab) as Music;
        DontDestroyOnLoad(m_music2);
        m_music2.SetAudioMixerGroup(MixerGroup);
    }

	public void Update ()
    {
        if (m_fade)
        {
            m_fade_count += Time.deltaTime;
            float param = Mathf.Min(m_fade_count / FadeTime, 1.0f);

            if (m_music1.IsPlay()) {
                m_music1.SetVolume(param);
            }
            if(m_music2.IsPlay())
            {
                m_music2.SetVolume(1.0f - param);
            }

            if (m_fade_count >= FadeTime)
            {
                m_fade_count = 0.0f;
                m_fade = false;
                Music tmp = m_music2;
                m_music2 = m_music1;
                m_music1 = tmp;
                m_music1.Stop();
            }
        }
        else if(m_request_num > 0)
        {
            bool change = true;

            // 同じ音源対応
            if(m_music2.IsPlay()){
                if( m_music2.IsSameAudioClip(m_request_musics[0])){
                    change = false;
                }
            }
            if (change){
                m_music1.Play(m_request_musics[0]);
                m_fade = true;
            }
            for(int i=0; i<m_request_num-1; i++){
                m_request_musics[i] = m_request_musics[i+1];
            }
            m_request_num--;
        }
	}

    // 変更
    public void ChangeMusic(MusicTable music)
    {
        if(m_request_num >= RequestMaxNum){
            return;
        }
        m_request_musics[m_request_num] = music;
        m_request_num++;
    }
}
