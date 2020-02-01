using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayerListCreator : MonoBehaviour
{

    [SerializeField]
    private Transform SpawnPoint;

    [SerializeField]
    private GameObject item;

    [SerializeField]
    private RectTransform content;

    private static int rowSize = 40;

    public static Dictionary<string, GamePlayerItemDetail> itemDetails;


    public void UpdateList(List<Player> players)
    {
        foreach (Transform child in SpawnPoint)
        {
            Destroy(child.gameObject);
        }
        itemDetails = new Dictionary<string, GamePlayerItemDetail>();

        content.sizeDelta = new Vector2(0, players.Count * rowSize);

        for (int i = 0; i < players.Count; i++)
        {
            Player player = players[i];
            AddPlayer(player, i);
        }
    }

    public void UpdatePlayer(Player player)
    {
        if (itemDetails.ContainsKey(player.id))
        {
            itemDetails[player.id].SetText(
                player.username,
                player.life,
                player.gold,
                player.income,
                player.id == NetworkManager.my_target
            );
        }
    }

    private void AddPlayer(Player player, int idx)
    {
        float spawnY = idx * rowSize;
        Vector3 pos = new Vector3(0, -spawnY, 0);
        GameObject listItem = Instantiate(item, pos, Quaternion.identity);

        listItem.transform.SetParent(SpawnPoint, false);
        GamePlayerItemDetail itDetail = listItem.GetComponent<GamePlayerItemDetail>();

        itDetail.SetText(player.username, player.life, player.gold, player.income, player.id == NetworkManager.my_target);
        itemDetails.Add(player.id, itDetail);
    }
}