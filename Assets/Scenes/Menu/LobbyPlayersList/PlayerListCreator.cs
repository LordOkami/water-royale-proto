using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerListCreator : MonoBehaviour
{

    [SerializeField]
    private Transform SpawnPoint;

    [SerializeField]
    private GameObject item;

    [SerializeField]
    private RectTransform content;

    private static int rowSize = 25;

    public void UpdateList(List<LobbyPlayer> players)
    {
        content.sizeDelta = new Vector2(0, players.Count * rowSize);

        foreach (Transform child in SpawnPoint)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < players.Count; i++)
        {
            LobbyPlayer player = players[i];

            float spawnY = i * rowSize;
            Vector3 pos = new Vector3(10, -spawnY, 0);
            GameObject listItem = Instantiate(item, pos, SpawnPoint.rotation);

            listItem.transform.SetParent(SpawnPoint, false);
            listItem.GetComponent<PlayerItemDetail>().SetText(player.username, player.ready);
        }
    }
}