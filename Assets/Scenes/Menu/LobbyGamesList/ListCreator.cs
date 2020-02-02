using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListCreator : MonoBehaviour
{

    [SerializeField]
    private Transform SpawnPoint;

    [SerializeField]
    private GameObject item;

    [SerializeField]
    private RectTransform content;

    int rowSize = 40;

    public void UpdateGameList(List<LobbyGame> games, MenuServerLobby lobby)
    {
        content.sizeDelta = new Vector2(0, games.Count * rowSize);

        foreach (Transform child in SpawnPoint)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < games.Count; i++)
        {
            LobbyGame game = games[i];

            float spawnY = i * rowSize;
            Vector3 pos = new Vector3(10, -spawnY, 0);
            GameObject listItem = Instantiate(item, pos, SpawnPoint.rotation);

            listItem.transform.SetParent(SpawnPoint, false);
            listItem.GetComponent<ItemDetail>().SetText(game.name, game.players.Count);
            listItem.GetComponent<Button>().onClick.AddListener(() => {
                lobby.SetSelectedGame(listItem, game.id);
            });
        }
    }
}