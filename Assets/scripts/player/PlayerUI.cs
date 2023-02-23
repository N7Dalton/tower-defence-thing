using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI promptText;
    public RawImage MP5image;
    public TextMeshProUGUI ammocount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (GameObject.Find("MP5") == null)
        {
           
            MP5image.enabled = false;
            ammocount.enabled = false;
        }
        if (GameObject.Find("MP5") != null)
        {
            
            MP5image.enabled = true;
            ammocount.enabled = true;
        }

    }
        // Update is called once per frame
        public void UpdateText(string promptMessage)
        {

        promptText.text = promptMessage;
        }
}
