using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{

    [Serializable]
    public class AudioClipData
    {
        public AudioClip Clip;
        public float Volume = 1f;
        public float minPitch = 1f;
        public float maxPitch = 1f;
    }

    public static AudioPlayer Instance;

    private AudioSource audioSource;
    private AudioSource musicAudioSource;

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
            musicAudioSource = gameObject.AddComponent<AudioSource>();
            musicAudioSource.playOnAwake = false;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(string name, GameObject go)
    {
        var clip = sfxClips.Find(x => x.Clip.name == name);
        if (audioSource.isPlaying)
        {
            AudioSource aS = go.GetComponent<AudioSource>();
            if (aS == null)
            {
                aS = go.AddComponent<AudioSource>();
            }
            aS.pitch = Random.Range(clip.minPitch, clip.maxPitch);
            aS.PlayOneShot(clip.Clip, clip.Volume);
        }
        else
        {
            audioSource.PlayOneShot(clip.Clip, clip.Volume);

        }
    }

    public void PlaySFX(int id, GameObject go)
    {
        var clip = sfxClips[id];
        if (audioSource.isPlaying)
        {
            AudioSource aS = go.GetComponent<AudioSource>();
            if (aS == null)
            {
                aS = go.AddComponent<AudioSource>();
            }
            aS.pitch = Random.Range(clip.minPitch, clip.maxPitch);
            aS.PlayOneShot(clip.Clip, clip.Volume);
        }
        else
        {
            audioSource.PlayOneShot(clip.Clip, clip.Volume);

        }
    }

    public void PlayMusic(string name)
    {
        var clip = musicClips.Find(x => x.Clip.name == name);
        musicAudioSource.clip = clip.Clip;
        musicAudioSource.volume = clip.Volume;
        musicAudioSource.loop = true;
        musicAudioSource.Play();
    }

    public void PlayMusic(int id)
    {
        var clip = musicClips[id];
        musicAudioSource.clip = clip.Clip;
        musicAudioSource.volume = clip.Volume;
        musicAudioSource.loop = true;
        musicAudioSource.Play();
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
