using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitiwalkPauser : Interactable
{
    public bool IsPressed = true;
    public GameObject button;
    private GameObject Titi;
    
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
        IsPressed = !IsPressed;
        Titi.GetComponent<Animator>().SetBool("IsPressed", IsPressed);

    }
}
