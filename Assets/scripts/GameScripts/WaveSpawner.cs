using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform Babytransform;

    public float timeBetweenRounds = 5f;
    private float countdownTimer = 3f;
    private int waveNumber = 1;
    private Vector3 randomspawnposition;
    public GameObject thirdlife;
    public GameObject secondlife;
    public GameObject firstlife;
    public int lives = 3;
    
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("RedButton").GetComponent<startButton>().buttonPressed == false)
        {

            if (countdownTimer <= 0f)
            {
                spawnwave();
                countdownTimer = timeBetweenRounds;
            }
            countdownTimer -= Time.deltaTime;
            
        }
    }
    void spawnwave()
    {
        if(waveNumber < 7)
        {
            for (int i = 0; i < waveNumber; i++)
            {
                spawnBABY();
            }
        }
        else
        {
            for (int i = 0; i < 7; i++)
            {
                spawnBABY();
            }
        }
        waveNumber++;
    }
    void spawnBABY()
    {
      
            randomspawnposition = new Vector3(Random.Range(8, -8), 0.7f, -17);
            Instantiate(Babytransform, randomspawnposition, Quaternion.identity);

    }
    public void lostlife()
    {
        lives = lives -1;
        if (lives == 2)
        {
            thirdlife.SetActive(false);
        }
        if (lives ==1)
        {
            secondlife.SetActive(false);
         
        }
        if (lives == 0)
        {
            firstlife.SetActive(false);
            Debug.Log("u lost loser");
        }
    }
    public void OpenDoor()
    {
        countdownTimer = 1;
        
    }
}
