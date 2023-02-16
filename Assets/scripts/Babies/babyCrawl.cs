using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class babyCrawl : MonoBehaviour
{
    public GameObject baby;
    public GameObject Base;
    public WaveSpawner wavespawner;
    // Start is called before the first frame update
    void Start()
    {
        wavespawner = GameObject.FindWithTag("Wave Spawner").GetComponent<WaveSpawner>();
        
    }

    // Update is called once per frame
    void Update()
    {
        baby.transform.Translate(0, 0, 5f* Time.deltaTime);
       
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Base")
        {
            Destroy(baby);
            wavespawner.lostlife();
        }
    }
    public void babyTakeDmg(int dmg)
    {
        GameManager.gameManager._playerHealth.DmgUnit(dmg);
    }
}
