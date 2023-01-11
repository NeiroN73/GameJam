using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SusremDIalog : MonoBehaviour
{

    public GameObject panelDialog;
    public Text dialog;
    public string[] message;
    public bool dialogStart = false;

    void Start()
    {
        message[0] = "Hello Mr. Root";
        message[1] = "Press the red button";
        panelDialog.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        panelDialog.SetActive(true);
        dialog.text = message[0];
        dialogStart = true;
    }

    public void OnTriggerExit(Collider other)
    {
        panelDialog.SetActive(false);
        dialogStart = false;
    }
    public void Update()
    {
        if (dialogStart == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                dialog.text = message[1];
            }
        }
    }
}
