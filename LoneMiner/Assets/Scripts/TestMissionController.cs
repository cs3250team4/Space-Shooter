using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestMissionController : MonoBehaviour
{

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
        goal = 1;
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
            AddScore(1);
            if (missionFailed || missionComplete)
            {
                break;
            }
        }
    }

    public void AddScore(int scoreValue)
    {
        score += scoreValue;
        if (score >= goal)
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
        //Time.timeScale = 0;
        SceneManager.LoadScene("ExploreMode2D");
        //SceneManager.LoadScene("OverWorld", LoadSceneMode.Additive);
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("OverWorld"));
    }
}