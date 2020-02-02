using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoaderController : MonoBehaviour
{
    public GameObject gamePrefab;
    public GameObject oponentPrefab;
    private int xPos = -10;
	private int sceneHeight = 10;

	private void Start()
	{
		AddPlayer(false);
		AddPlayer(true);
		AddPlayer(false);
	}


	private void Update()
	{
	
	}

	private void AddPlayer(bool isLocalPlayer)
	{
        if(isLocalPlayer)
        {
            var game = Instantiate(gamePrefab);
            game.transform.position = new Vector3(xPos, 0f, 0f);
        } else
        {
            var game = Instantiate(oponentPrefab);
            game.transform.position = new Vector3(xPos, 0f, 0f);
        }
        xPos += sceneHeight;
    }
}
