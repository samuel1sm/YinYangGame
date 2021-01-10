using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public  SoundAudioClip[] audioClips;

    private static Dictionary<Sound, float> soundTimerDictionary;

    private void Awake()
    {
        soundTimerDictionary = new Dictionary<Sound, float>();
        soundTimerDictionary[Sound.PlayerMove] = 0f;
    }

    public void PlaySound(Sound sound)
    {
        SoundAudioClip sc = GetAudioClip(sound);
        if (CanPlaySound(sc))
        {
            print("dada");
            GameObject soundGameObject = new GameObject("Sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.PlayOneShot(sc.audioClip);
            Destroy(soundGameObject, soundTimerDictionary[Sound.PlayerMove]);
        }
    }

    private static bool CanPlaySound(SoundAudioClip newSound)
    {
        switch (newSound.sound)
        {
            default:
                return true;
            case Sound.PlayerMove:
                if (soundTimerDictionary.ContainsKey(newSound.sound))
                {
                    float lastTimePlayed = soundTimerDictionary[newSound.sound];
                    float playerMoverTimerMax = newSound.audioTime;

                    if (lastTimePlayed + playerMoverTimerMax < Time.time)
                    {
                        soundTimerDictionary[newSound.sound] = Time.time;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
                break;

        }
    }

    private  SoundAudioClip GetAudioClip(Sound soundToPlay)
    {
        foreach (SoundAudioClip sc in audioClips)
        {
            if (sc.sound == soundToPlay)
            {
                return sc;
            }
        }
        Debug.LogError("Sound " + soundToPlay + " not found!");
        return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
