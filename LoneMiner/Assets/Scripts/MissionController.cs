/*
 * Orginal code by Adam Buckner: https://www.linkedin.com/in/adam-buckner-vfx
 * From Unity Tutorial:
 * https://unity3d.com/learn/tutorials/projects/space-shooter-tutorial/extending-space-shooter-enemies-more-hazards?playlist=17147
 * 
 * Modified by Joe Turner mailto:jturne48@msudenver.edu
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MissionController : MonoBehaviour {

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    private bool missionFailed;
    private bool missionComplete;
    private int score;
    public int goal;

    public GameObject text;

    void Start()
    {
        Time.timeScale = 1;
        missionFailed = false;
        missionComplete = false;
        score = 0;
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (missionFailed || missionComplete)
            {
                break;
            }
        }
    }

    public void AddScore(int scoreValue)
    {
        score += scoreValue;
        if(score >= goal)
        {
            MissionComplete();
        }
    }

    public void MissionFailed()
    {
        missionFailed = true;
        text.GetComponent<Text>().text = "MISSION FAILED";
        StartCoroutine(Wait());
    }

    public void MissionComplete()
    {
        missionComplete = true;
        text.GetComponent<Text>().text = "MISSION COMPLETE";
        StartCoroutine(Wait());        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.0f);
        Time.timeScale = 0;
        SceneManager.LoadScene("MainMenu");
    }
}