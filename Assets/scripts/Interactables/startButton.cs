using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startButton : Interactable
{
    public GameObject button;
    [SerializeField]
    private GameObject door;
    private bool buttonPressed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void Interact()
    {
        buttonPressed = !buttonPressed;
        door.GetComponent<Animator>().SetBool("IsOpen", buttonPressed);

    }



}
