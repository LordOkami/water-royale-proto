using UnityEngine;
using TMPro;

public class ItemDetail : MonoBehaviour
{

    public void SetText(string name, int count)
    {
        TextMeshProUGUI gameName = transform.Find("GameNameText").gameObject.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI gameDetail = transform.Find("GamePlayersText").gameObject.GetComponent<TextMeshProUGUI>();

        gameName.text = name;
        gameDetail.text = count.ToString() + " players";
    }
}
