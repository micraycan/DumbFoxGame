using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinGameText : MonoBehaviour
{
    private Text winText;

    // Start is called before the first frame update
    void Start()
    {
        winText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        winText.text = "congratulations, your total time to complete was " + PlayerPrefs.GetFloat("TotalTime").ToString("F2");
    }
}
