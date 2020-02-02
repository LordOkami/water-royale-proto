using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GamePlayerItemDetail : MonoBehaviour
{

    public void SetText(string _username, int _life, int _gold, int _income, bool target)
    {
        TextMeshProUGUI username = transform.Find("UsernameText").gameObject.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI life = transform.Find("LifeText").gameObject.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI gold = transform.Find("GoldText").gameObject.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI income = transform.Find("IncomeText").gameObject.GetComponent<TextMeshProUGUI>();
        username.text = _username;
        life.text = _life + "";
        gold.text = _gold + "";
        income.text = _income + "";

        if( _life == 0)
        {
            gameObject.GetComponent<Image>().color = new Color32(45, 45, 45, 145);
        } else if (target)
        {
            gameObject.GetComponent<Image>().color = new Color32(255, 20, 20, 120);
        }
    }
}
