using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject obj_Wall;

    [SerializeField]
    private int int_Count;

    [SerializeField]
    private Text txt_Input;

    private 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            txt_Input.text = "Fire1";
        }
        if (Input.GetButton("Fire2"))
        {
            txt_Input.text = "Fire2";
        }
        if (Input.GetButton("ButtonA"))
        {
            txt_Input.text = "ButtonA";
        }
        if (Input.GetButton("ButtonB"))
        {
            txt_Input.text = "ButtonB";
        }
        if (Input.GetButton("ButtonC"))
        {
            txt_Input.text = "ButtonC";
        }
        if (Input.GetButton("ButtonD"))
        {
            txt_Input.text = "ButtonD";
        }
        if (int_Count == 4)
        {
            obj_Wall.SetActive(false);
        }
        //Fin
    }

    private void OnTriggerEnter(Collider coll_Other)
    {
        if (coll_Other.gameObject.CompareTag("Coin"))
        {
            Destroy(coll_Other.gameObject);
            int_Count++;
        }
    }
}