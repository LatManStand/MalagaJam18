using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{

    [Serializable]
    public class AudioClipData
    {
        public AudioClip Clip;
        public float Volume;
    }

    public static AudioPlayer Instance;

    private AudioSource audioSource;

    [SerializeField]
    private List<AudioClipData> musicClips;
    [SerializeField]
    private List<AudioClipData> sfxClips;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(string name)
    {
        var clip = sfxClips.Find(x => x.Clip.name == name);
        audioSource.PlayOneShot(clip.Clip, clip.Volume);
    }

    public void PlaySFX(int id)
    {
        var clip = sfxClips[id];
        audioSource.PlayOneShot(clip.Clip, clip.Volume);
    }

    public void PlayMusic(string name)
    {
        var clip = musicClips.Find(x => x.Clip.name == name);
        audioSource.clip = clip.Clip;
        audioSource.volume = clip.Volume;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void SetMute(bool isMuted)
    {
        audioSource.mute = isMuted;
    }

    public void StopAudioPlayer()
    {
        audioSource.Stop();
    }
}
