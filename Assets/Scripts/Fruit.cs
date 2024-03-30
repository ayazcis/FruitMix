using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Fruit : MonoBehaviour
{
	public List<GameObject> fruitPrefabs = new List<GameObject>();
	private int range;
	private GameObject GameManager;
	private Rigidbody2D rgb;
	private ScoreManager scoreManager;
	private GameOver gameOverScript;
	private Dragging dragging;
	private SpriteRenderer SpriteRenderer;
    private Collider2D Collider;
	private static List<string> collidedObjects = new List<string>();
	private bool hasInitiatedCollision = false;
	public bool freezed = false;
	private RewardedAdd RewardedAdd;
	private FruitSpawner FruitSpawner;
	private AudioSource AudioSource;

	private void Awake()
	{
		rgb = GetComponent<Rigidbody2D>();	
		dragging = GetComponent<Dragging>();
		SpriteRenderer = GetComponent<SpriteRenderer>();
        Collider = GetComponent<Collider2D>();
		GameManager = GameObject.Find("GameManager");
		scoreManager  = GameManager.GetComponent<ScoreManager>();
		gameOverScript = GameManager.GetComponent<GameOver>();
		RewardedAdd = GameManager.GetComponent<RewardedAdd>();
		FruitSpawner = GameManager.GetComponent<FruitSpawner>();
		AudioSource = GameManager.GetComponent<AudioSource>();
	}
	private void Start()
	{
		foreach(GameObject f in fruitPrefabs)
        {
            if(f.name == gameObject.name)
            {
                range = fruitPrefabs.IndexOf(f);
            }
        }
	}
	private void Update()
	{
		if(dragging.dragged && transform.position.y >= 1.1f)
		{
			Invoke("StillOver", 1.5f);
		}
		if (RewardedAdd.addWatched)
		{
			dragging.addWatching = false;
		}
		if (dragging.addWatching && transform.position.y >= 1.1f)
		{
			Destroy(gameObject);
		}
	}


	private void OnCollisionEnter2D(Collision2D collision)
	{
		
		Fruit otherFruit = collision.gameObject.GetComponent<Fruit>();
		if ((!dragging.dragged && otherFruit != null) )
		{
			dragging.addWatching = true;
			gameOverScript.gameOver = true;
			Debug.Log("deðdi " + collision.gameObject.name);
			Destroy(otherFruit,4.5f);
			Destroy(gameObject, 4.5f);
			FruitSpawner.fruitDropped = true;
			dragging.dragged = true;



		}

		if (otherFruit != null && otherFruit.range == range && !hasInitiatedCollision && !otherFruit.hasInitiatedCollision)
        {
			hasInitiatedCollision=true;
			//SpriteRenderer.enabled = false;
			//otherFruit.SpriteRenderer.enabled = false;
			int tmp = range;
			Vector3 tempLoc = transform.position;
			if(tmp+1 < fruitPrefabs.Count)
			{
				scoreManager.score += range * 3 + 2;
				AudioSource.Play();
				GameObject newFruit = Instantiate(fruitPrefabs[tmp + 1], tempLoc, Quaternion.identity);

				Rigidbody2D newFruitRgb = newFruit.GetComponent<Rigidbody2D>();
				Dragging newFruitDragging = newFruit.GetComponent<Dragging>();
				newFruitDragging.dragged = true;
				newFruitRgb.constraints = RigidbodyConstraints2D.None;
				Destroy(otherFruit.gameObject);
				Destroy(gameObject);
			}
			
		}
    }

	private void StillOver()
	{
		if (dragging.dragged && transform.position.y >= 1.1f)
		{
			//FruitSpawner.fruitDropped = true;
			dragging.addWatching = true;
			gameOverScript.gameOver = true;
			Destroy(gameObject,0.5f);
			Debug.Log("yukarDA");
		}
	}

}
///m]z'k kapama oyun game over sýnýrý ve ikili basma 
