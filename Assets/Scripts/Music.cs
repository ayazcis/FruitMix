using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
	AudioSource source;
	public Image ImageMute;
	public Image imageMusic;
	private void Awake()
	{
		GameObject sound = GameObject.Find("Sound");
		source = sound.GetComponent<AudioSource>();
		ImageMute.enabled = false;
	}

	public void changeMusic()
	{
		if (source.volume == 0f)
		{
			imageMusic.enabled = true ;
			ImageMute.enabled = false;
			source.volume = 0.055f;
		}
		else
		{
			imageMusic.enabled = false;
			ImageMute.enabled = true;
			source.volume = 0f;
		}
	}
}
