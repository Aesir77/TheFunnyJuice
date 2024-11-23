using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PaperController : MonoBehaviour
{
    [SerializeField] private KeyCode closeKey;
    [SerializeField] private GameObject paper;
    [SerializeField] private TMP_Text noteTextUI;
    [SerializeField]
    [TextArea] private string noteText;
    private bool isOpen = false;
    public void ShowNote()
    {
        noteTextUI.text = noteText;
        paper.SetActive(true);
        isOpen = true;
    }
    void DisableNote()
    {
        paper.SetActive(false);
        isOpen = false;
    }

    private void Update()
    {
        if (isOpen)
        {
            if (Input.GetKeyDown(closeKey))
            {

                DisableNote();
            }
        }
    }
}

