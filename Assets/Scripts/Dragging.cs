using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dragging : MonoBehaviour
{
	Vector3 offset;
	private Rigidbody2D rgb;
	public bool dragged = false;
	private FruitSpawner spawner;
	private GameObject manager;
	private Collider2D cld;
	private GameOver GameOver;
	public bool addWatching = false;


	private void Awake()
	{
		GameObject gameManager = GameObject.Find("GameManager");
		GameOver = gameManager.GetComponent<GameOver>();
		cld = GetComponent<Collider2D>();
		rgb = GetComponent<Rigidbody2D>();
		rgb.constraints = RigidbodyConstraints2D.FreezePositionY;
		manager = GameObject.Find("GameManager");
		spawner = manager.GetComponent<FruitSpawner>();
	}
	/*void OnMouseDown()
	{

		if (!dragged)
		{
			offset = transform.position - MouseWorldPosition();
		}
		
	}


	void OnMouseDrag()
	{
		if (!dragged) {
			transform.position = MouseWorldPosition() + offset;
		}
		
	}
	private void OnMouseUp()
	{
		Debug.Log(spawner);
		dragged = true;
		rgb.constraints = RigidbodyConstraints2D.None;
		Debug.Log("ssss");
		spawner.fruitDropped = true;


	}*/
	

	Vector3 MouseWorldPosition()
	{
		var mouseScreenPos = Input.mousePosition;
		mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
		mousePos.y = transform.position.y;
		return mousePos;
	}
	private void Update()
	{
		if (dragged)
		{
			rgb.constraints = RigidbodyConstraints2D.None;
		}
		if (!dragged && Input.touchCount > 0 && !GameOver.gameOver && !addWatching)
		{
			
			Touch touch = Input.GetTouch(0);
			Vector3 touchScreenPos = touch.position;
			touchScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
			Vector3 touchpos = Camera.main.ScreenToWorldPoint(touchScreenPos);
			touchpos.y = transform.position.y;
			switch (touch.phase)
			{
				case TouchPhase.Began:
					offset = transform.position - touchpos;
					transform.position = touchpos + offset;
					break;

				case TouchPhase.Moved:
					transform.position = touchpos + offset;
					break;
				case TouchPhase.Ended:
					rgb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
					dragged = true;
					spawner.fruitDropped = true;

					break;

			}
		}
		
	
	}



}


