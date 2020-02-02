using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownBehaviour : MonoBehaviour
{

    public static bool updateCountdown;
    public static int countdown = 3;

    public GameObject countdownUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (updateCountdown)
        {
            updateCountdown = false;
            if (countdown == 0)
            {
                countdownUI.SetActive(false);
            }
            else
            {
                setImage(countdown);
                countdownUI.SetActive(true);
            }
        }
    }

    void setImage(int count)
    {
        disableAllImages();
        switch (count)
        {
            case 4:
                countdownUI.transform.Find("3").GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 3:
                countdownUI.transform.Find("2").GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 2:
                countdownUI.transform.Find("1").GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 1:
                countdownUI.transform.Find("Start").GetComponent<SpriteRenderer>().enabled = true;
                break;
        }
    }

    void disableAllImages()
    {
        foreach(SpriteRenderer spriteRenderer in countdownUI.GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderer.enabled = false;
        }
    }

    public static void UpdateCountdown(int count)
    {
        countdown = count;
        updateCountdown = true;
    }
}
