using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHolder : MonoBehaviour
{
	public int Score;
	public bool maxScore = false;
	public bool addShowedOnce = false;
	private void Awake()
	{
		DontDestroyOnLoad(this);
	}
	

}
