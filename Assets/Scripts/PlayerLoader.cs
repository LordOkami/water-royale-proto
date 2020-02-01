﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLoader : MonoBehaviour
{

	int scenesLoaded = 0;
	public void Load(string roomName)
	{
		SceneManager.sceneLoaded += SceneManager_sceneLoaded;
		SceneManager.LoadSceneAsync(roomName, LoadSceneMode.Additive);
	}

	private void SceneManager_sceneLoaded(Scene scene, LoadSceneMode mode)
	{
		SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
		StartCoroutine(MoveAfterLoad(scene));
	}

	private IEnumerator MoveAfterLoad(Scene scene)
	{
		while (scene.isLoaded == false)
		{
			yield return new WaitForEndOfFrame();
		}

		var rootGameObjects = scene.GetRootGameObjects();
		foreach (var rootGameObject in rootGameObjects)
		{

			rootGameObject.transform.position += new Vector3(rootGameObject.transform.localScale.x*scenesLoaded,0,0);
		}
			

		scenesLoaded++;
	}
}
