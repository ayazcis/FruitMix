using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{
    public bool gameOver;
	public Button addButton;
	public ScoreManager scoreManager;
	public GameObject gameOverCanvas;
	private bool addWatch = false;
	private GameObject scoreHolderObject;
	private ScoreHolder scoreHolder;
	public FruitSpawner FruitSpawner;
	


	private void Awake()
	{
		scoreHolderObject = GameObject.Find("ScoreHolder");
		scoreHolder = scoreHolderObject.GetComponent<ScoreHolder>();
		scoreHolder.addShowedOnce = false;
		if (!scoreHolder.addShowedOnce)
		{
			addButton.onClick.AddListener(buttonIsCliked);
		}
		addWatch = false;
		gameOver = false;
		gameOverCanvas.SetActive(false);
	}
	private void Start()
	{
		GameObject rewardedAddObject = GameObject.Find("GameManager");
		RewardedAdd rewardedAddScript = rewardedAddObject.GetComponent<RewardedAdd>();
		rewardedAddScript.LoadAd();
	}
	private void buttonIsCliked()
	{
		addWatch = true;
	}
	private void Update()
	{
		if (gameOver)
		{
			if (!scoreHolder.addShowedOnce)
			{
				gameOverCanvas.SetActive(true);
				Invoke("MakeItOver", 5f);

				if (addWatch)
				{
					Debug.Log("addwatcha girdiBUTTONCLÝKED");
					scoreHolder.addShowedOnce = true;
					gameOver = false;
					gameOverCanvas.SetActive(false);
				}
			}
			else
			{
			
				gameOver = true;
				scoreManager.GameOver();
				PlayerPrefs.SetInt("Score", scoreManager.score);

				SceneManager.LoadScene(2);
				Debug.Log("gam e ýever");
			}
			
			


		}
		else
		{
			gameOverCanvas.SetActive(false);
		}
		
	}
	private void MakeItOver()
	{
		if (!scoreHolder.addShowedOnce)
		{
			gameOver = true;
			scoreManager.GameOver();
				PlayerPrefs.SetInt("Score", scoreManager.score);

				SceneManager.LoadScene(2);
				Debug.Log("gam e ýever");
			
		}
		
			
		
	}
	
}
