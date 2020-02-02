using UnityEngine;
using TMPro;

public class PlayerItemDetail : MonoBehaviour
{

    public void SetText(string name, bool ready)
    {
        TextMeshProUGUI gameName = transform.Find("PlayerNameText").gameObject.GetComponent<TextMeshProUGUI>();
        gameName.text = name;
        transform.Find("PlayerReadyText").gameObject.SetActive(ready);
    }
}
