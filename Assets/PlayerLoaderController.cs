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
		AddPlayer(NetworkManager.my_attacker_player);
		AddPlayer();
		AddPlayer(NetworkManager.my_target_player);
	}


	private void Update()
	{
	
	}

    private void AddPlayer()
    {
        var game = Instantiate(gamePrefab);
        game.transform.position = new Vector3(xPos, 0f, 0f);
        xPos += sceneHeight;
    }

    private void AddPlayer(Player oponent)
	{

        var game = Instantiate(oponentPrefab);
        game.GetComponent<OponentGameController>().oponentPlayer = oponent;
        game.transform.position = new Vector3(xPos, 0f, 0f);
        xPos += sceneHeight;
    }
}
