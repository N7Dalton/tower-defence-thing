using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class babyCrawl : MonoBehaviour
{
    public GameObject Titi;
    public GameObject Base;
    public WaveSpawner wavespawner;
    public bool roundistrue = true;
    // Start is called before the first frame update
    void Start()
    {
        wavespawner = GameObject.FindWithTag("Wave Spawner").GetComponent<WaveSpawner>();
        Base = GameObject.FindWithTag("Base").GetComponent<GameObject>();
        Titi = GameObject.FindWithTag("Baby").GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("RedButton").GetComponent<startButton>().buttonPressed == false)
        {

            transform.Translate(0, 0, 5f * Time.deltaTime);

        }
       
            
       
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Base")
        {
            Destroy(this.gameObject);
            wavespawner.lostlife();
        }
    }
    public void babyTakeDmg(int dmg)
    {
        GameManager.gameManager._playerHealth.DmgUnit(dmg);
    }
    
}
