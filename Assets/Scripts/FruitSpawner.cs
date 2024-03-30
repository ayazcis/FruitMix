using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class FruitSpawner : MonoBehaviour
{
	public Fruit fruitScript;
    private int fruitCount;
	public bool fruitDropped;
	private Vector3 spawnPos = new Vector3(1.28999996f, 2.63000011f, 0);
	public GameOver gameover;
	
	private void Awake()
	{
		fruitCount =  fruitScript.fruitPrefabs.Count;
		
	}
	private void Start()
	{
		fruitDropped = false;
	}
	private void Update()
	{

		if (fruitDropped)
		{
			fruitDropped = false;
			if (!gameover.gameOver)
			{
				Invoke("SpawnFruit", 1.1f);
				
			}
			

		}
	}

	public void SpawnFruit()
	{
		int random = Random.Range(0, fruitCount-4);
		GameObject newfruit =Instantiate(fruitScript.fruitPrefabs[random], spawnPos, Quaternion.identity);

		Dragging newFruitsDragging= newfruit.GetComponent<Dragging>();
		newFruitsDragging.dragged = false;
		fruitDropped = false;
	}
}
