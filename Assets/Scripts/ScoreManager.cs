using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
	public int score=0;
    private GameData gameData;
	private GameObject scoreHolder;
	private ScoreHolder scoreHolderScript;
	public TMP_Text ScoreText;
	public TMP_Text NewMaxText;

	private void Awake()
	{
		gameData = SaveSystem.Load();
		NewMaxText.enabled = false;
		Debug.Log("max: " + gameData.maxScore);
		gameData = SaveSystem.Load();
		score = PlayerPrefs.GetInt("Score");
		scoreHolder = GameObject.Find("ScoreHolder");
		scoreHolderScript = scoreHolder.GetComponent<ScoreHolder>();
		score = scoreHolderScript.Score;
	}
	private void Update()
	{
		
		scoreHolderScript.Score = score;
	
		ScoreText.text = scoreHolderScript.Score.ToString();
	}


	public void GameOver()
	{
		if(gameData.maxScore < score)
		{
			gameData.maxScore = score;
			SaveSystem.Save(gameData);
			NewMaxText.enabled = true;
			scoreHolderScript.maxScore = true;
		}
	}

	public void PlayAgainButton()
	{
		scoreHolderScript.Score = 0;
		score = 0;
		SceneManager.LoadScene(1);
	}
	


}
