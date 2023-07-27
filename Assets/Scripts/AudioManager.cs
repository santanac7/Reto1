using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager intance;
    [SerializeField] AudioMixer _audioMixer;

    bool _musicMute = false;
    bool _sfxMute = false;

    // Audio Source List
    [SerializeField] AudioSource _audioSource;
    [SerializeField] List<AudioClip> _soundList = new List<AudioClip>();

    public PlayerDeath _player;


    private void Awake() {
        if (AudioManager.intance == null){
            AudioManager.intance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    #region  Volume and mute Methods
    
    public void MuteMusic(){
        if (!_musicMute)
        {
            ChangeMusicVolume(-80);
        }
        else
        {
            ChangeMusicVolume(0);
        }
        _musicMute = ! _musicMute;
    }

    public void MuteSfx(){
        if (!_sfxMute)
        {
            ChangeSfxVolume(-80);
        }
        else
        {
            ChangeSfxVolume(0);
        }
        _sfxMute = ! _sfxMute;
    }

    public void ChangeMusicVolume(float _newVolume){
        _audioMixer.SetFloat("MusicVolume", _newVolume);
    }

    public void ChangeSfxVolume(float _newVolume){
        _audioMixer.SetFloat("SfxVolume", _newVolume);
    }

    public float GetMusicVolume(){
        float _currentVolume;
        _audioMixer.GetFloat("MusicVolume", out _currentVolume);
        return _currentVolume;
    }

    public float GetSfxVolume(){
        float _currentVolume;
        _audioMixer.GetFloat("SfxVolume", out _currentVolume);
        return _currentVolume;
    }

    #endregion

    public void PlaySfx(int _sfx){
        AudioClip clip = _soundList[_sfx];
        _audioSource.PlayOneShot(clip);
    }     
    
    public void StopSfx(int _sfx){
        AudioClip clip = _soundList[_sfx];
        _audioSource.Stop();
    }    
}