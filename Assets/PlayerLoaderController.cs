using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoaderController : MonoBehaviour
{
    public GameObject gamePrefab;
    public GameObject oponentPrefab;
    private int xPos = -10;
	private int sceneHeight = 10;

  OponentGameController attackerGame, targetGame;
  IndividualGameController myGame;

  public static ValveSpawn addValveSpawn = null;
	private void Start()
	{
		attackerGame = AddPlayer(true);
		myGame = AddPlayer();
		targetGame = AddPlayer(false);
	}


	private void FixedUpdate()
	{
    if( addValveSpawn != null ){
      attackerGame.spawnValve(addValveSpawn);
      myGame.spawnValve(addValveSpawn);
      targetGame.spawnValve(addValveSpawn);
      addValveSpawn = null;
    }
	}

    private IndividualGameController AddPlayer()
    {
        var game = Instantiate(gamePrefab);
        IndividualGameController gg = game.GetComponent<IndividualGameController>();
        game.transform.position = new Vector3(xPos, 0f, 0f);
        xPos += sceneHeight;
        return gg;
    }

    private OponentGameController AddPlayer(bool attacker)
	{
        var game = Instantiate(oponentPrefab);
        OponentGameController gg = game.GetComponent<OponentGameController>();
        gg.attacker = attacker;
        game.transform.position = new Vector3(xPos, 0f, 0f);
        xPos += sceneHeight;
        return gg;
    }
}
