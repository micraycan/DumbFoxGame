using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float totalTime;

    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        startTime = Time.timeSinceLevelLoad;
        // Debug.Log(startTime.ToString("F2"));
    }

    public void EndGame()
    {
        StartCoroutine(Pause(1));
    }

    private IEnumerator Pause(int p)
    {
        Time.timeScale = 0.000001f;
        yield return new WaitForSeconds(p * Time.timeScale);
        Time.timeScale = 1;
        GameObject.FindObjectOfType<SceneLoader>().GameOver();
    }

    public void PickUpGem()
    {
        PlayerPrefs.SetFloat("TotalTime", startTime);
        GameObject.FindObjectOfType<SceneLoader>().WinGame();
    }
}
