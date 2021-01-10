using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Range(0f, 1f)]
    [SerializeField] float efectsVolume = 1;
    [Range(0f, 1f)]
    [SerializeField] float musicVolume = 1;

    public  SoundAudioClip[] audioClips;
    private static Dictionary<Sound, float> soundTimerDictionary;
    private AudioSource musicPlayerSource;

    private void Awake()
    {
        soundTimerDictionary = new Dictionary<Sound, float>();
        soundTimerDictionary[Sound.PlayerMove] = 0f;
        int scene = GameManager.gameManager.GetThisScene();
        GameObject musicPlayer = new GameObject("LevelSound");
        musicPlayerSource = musicPlayer.AddComponent<AudioSource>();
        musicPlayerSource.volume = musicVolume;

        if (scene == 0)
        {
   
            musicPlayerSource.clip = GetAudioClip(Sound.Menu).audioClip;
            

        }
        else if (scene == 1)
        {
            musicPlayerSource.clip = GetAudioClip(Sound.LevelScreen).audioClip;

        }
        else
        {
            musicPlayerSource.clip = GetAudioClip(Sound.Level).audioClip;

        }

        musicPlayerSource.Play();
    }

    

    public void PlaySound(Sound sound)
    {
        SoundAudioClip sc = GetAudioClip(sound);
        if (CanPlaySound(sc))
        {
            GameObject soundGameObject = new GameObject("Sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.PlayOneShot(sc.audioClip, efectsVolume);
            Destroy(soundGameObject, sc.audioClip.length);
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
        musicPlayerSource.volume = musicVolume;

    }
}
