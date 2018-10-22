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

public class DotEMissionController : MonoBehaviour {

    public GameObject DotE;
    public GameObject[] hazards;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    private bool missionFailed;
    private bool missionComplete;    

    public GameObject text;
       
	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        missionFailed = false;
        missionComplete = false;
        StartCoroutine(SpawnWaves());
    }
	
	// Update is called once per frame
	void Update () {

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

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                if (DotE != null)
                {
                    float min = DotE.transform.position.x - 5;
                    float max = DotE.transform.position.x + 5;
                    Vector3 spawnPosition = new Vector3(Random.Range(min, max), 0.0f, DotE.transform.position.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard, spawnPosition, spawnRotation);
                }
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            spawnWait *= 0.9f;
            waveWait *= 0.9f;
            hazardCount *= 2;
            if (missionFailed || missionComplete)
            {
                break;
            }
        }
    }
}
