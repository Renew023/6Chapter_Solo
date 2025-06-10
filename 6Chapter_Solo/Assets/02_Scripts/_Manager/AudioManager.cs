using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [Header("볼륨 조절")]
    [SerializeField] private AudioSource[] BGMSources;
    [SerializeField] private AudioSource[] SFXSources;

    [Header("배경음악")]
	[SerializeField] public AudioSource BGMSource_1;
	[SerializeField] public AudioSource BGMSource_2;

    [Header("효과음")]
    [SerializeField] public AudioSource SFXSource_Attack;
	[SerializeField] public AudioSource SFXSource_Running;
	[SerializeField] public AudioSource SFXSource_Death;
	[SerializeField] public AudioSource SFXSource_Button;
	[SerializeField] public AudioSource SFXSource_LevelUp;

	protected override void Awake()
    {
        DontDestroyOnLoad(gameObject);
		base.Awake();
        BGMSource_1.Play();
    }

    public void SetBGMVolume(float volume)
	{
		foreach (var bgm in BGMSources)
		{
			bgm.volume = volume;
		}
	}
	public void SetSFXVolume(float volume)
	{
		foreach (var sfx in SFXSources)
		{
			sfx.volume = volume;
		}
	}

}
