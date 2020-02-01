using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoaderController : MonoBehaviour
{
	private int xPos = 0;
	private int playerIdx = 0;
	private int height = 10;

	private void Start()
	{
		AddPlayer("Single");
		AddPlayer("Single");
	}


	private void Update()
	{
	
	}

	private void AddPlayer(string playerName)
	{
		xPos += height;

		var playerLoader = new GameObject("PlayerLoader").AddComponent<PlayerLoader>();
		playerLoader.transform.position = new Vector3(xPos, 0f,0f );
		playerLoader.Load(playerName);
	}
}
