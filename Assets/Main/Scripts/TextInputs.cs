using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InControl;

public class TextInputs : MonoBehaviour
{

    [SerializeField]
    Text text, text2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var inputDevice in InputManager.Devices)
        {

            text2.text = "/n" + "  Input name: " + inputDevice.Name;

            var anybutton = inputDevice.AnyButton;
            //var anystick = 
            if(anybutton)
            {
                text.text = anybutton.Handle;
            }
        }

    }
}
