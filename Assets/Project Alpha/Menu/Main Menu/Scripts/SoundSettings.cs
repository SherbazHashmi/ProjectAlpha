using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MoreMountains.CorgiEngine.SoundManager
{

    [Header("Sound Variables")]
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider SFXSlider;
    public Toggle muteSound;

    public override void PlayBackgroundMusic(AudioSource Music)
    {
        if (!MusicOn)                                                                                           // if the music's been turned off, we do nothing and exit
        {
            return;
        }

        if (_backgroundMusic != null)                                                                           // if we already had a background music playing, we stop it
        {
            _backgroundMusic.Stop();
        }

        _backgroundMusic = Music;                                                                               // we set the background music clip        
        _backgroundMusic.volume = musicSlider.value;                                                            // we set the music's volume        
        _backgroundMusic.loop = true;                                                                           // we set the loop setting to true, the music will loop forever        
        _backgroundMusic.Play();                                                                                // we start playing the background music
    }

    public override AudioSource PlaySound(AudioClip sfx, Vector3 location, bool loop = false)
    {
        if (!SfxOn)
        {
            return null;
        }           
        
        GameObject temporaryAudioHost = new GameObject("TempAudio");                                            // we create a temporary game object to host our audio source        
        temporaryAudioHost.transform.position = location;                                                       // we set the temp audio's position
        
        AudioSource audioSource = temporaryAudioHost.AddComponent<AudioSource>() as AudioSource;                // we add an audio source to that host        
        audioSource.clip = sfx;                                                                                 // we set that audio source clip to the one in paramaters        
        audioSource.volume = SFXSlider.value;                                                                   // we set the audio source volume to the one in parameters        
        audioSource.loop = loop;                                                                                // we set our loop setting        
        audioSource.Play();                                                                                     // we start playing the sound

        if (!loop)
        {            
            Destroy(temporaryAudioHost, sfx.length);                                                            // we destroy the host after the clip has played
        }        
        return audioSource;                                                                                     // we return the audiosource reference
    }
}
