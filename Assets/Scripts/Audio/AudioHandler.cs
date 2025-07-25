using UnityEngine;
using UnityEngine.Audio;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    private const float OffVolume = -80f;
    private const float OnVolume = 0f;

    private const string MusicVolume = "MusicVolume";
    private const string SoundsVolume = "SoundsVolume";

    private bool _musicState = true;
    private bool _soundsState = true;

    public void MusicState()
    {
        if (_musicState)
            OffMusic();
        else
            OnMusic();
    }

    public void SoundsState()
    {
        if (_soundsState)
            OffSounds();
        else
            OnSounds();
    }

    private void OffMusic()
    {
        _audioMixer.SetFloat(MusicVolume, OffVolume);
        _musicState = false;
    }
    private void OnMusic()
    {
        _audioMixer.SetFloat(MusicVolume, OnVolume);
        _musicState = true;
    }
    private void OffSounds()
    {
        _audioMixer.SetFloat(SoundsVolume, OffVolume);
        _soundsState = false;
    }
    private void OnSounds()
    {
        _audioMixer.SetFloat(SoundsVolume, OnVolume);
        _soundsState = true;
    }
}
