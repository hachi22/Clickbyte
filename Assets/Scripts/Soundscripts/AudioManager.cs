using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Audio;
using UnityEngine;
using TMPro;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;

    private bool mute;

    [SerializeField] private TextMeshProUGUI textMute;

    void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }


        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;


            s.source.volume = s.volume;
            s.originalVolume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
    }

    void Start()
    {
        Play("Main Theme"); //iniciar música principal

    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void PlayKeyBoard()
    {
        switch (UnityEngine.Random.Range(1,4    ))
        {
            case 1:
                Sound s = Array.Find(sounds, sound => sound.name == "click1");
                s.source.Play();
                break;
            case 2:
                s = Array.Find(sounds, sound => sound.name == "click2");
                s.source.Play();
                break;
            case 3:
                s = Array.Find(sounds, sound => sound.name == "click3");
                s.source.Play();
                break;
        }
    }

    public void SetVolume(string name, int volume)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.volume = volume;
    }

    public void Mute()
    {
        if (!mute)
        {
            foreach (Sound s in sounds)
            {
                s.source.volume = 0;
            }
            textMute.text = "Unmute";
}
        else
        {
            foreach (Sound s in sounds)
            {
                s.source.volume = s.originalVolume;
            }
            textMute.text = "mute";
        }
        mute = !mute;
    }

}