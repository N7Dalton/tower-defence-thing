using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public bool ispaused;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && ispaused == false)
        {
            Debug.Log("hit escape");
            Time.timeScale = 0f;
            ispaused = true;
            
        }
        else if(ispaused == true)
        {
            Time.timeScale = 1.0f;
            ispaused = false;
        }
                
            
    }
}
