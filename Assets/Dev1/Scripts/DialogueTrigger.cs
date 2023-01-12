using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueSystem _dialogueSystem;

    [SerializeField] private List<string> _dialogueText;

    private bool _checkTrigger;

    private void Start()
    {
        _dialogueSystem = FindObjectOfType<DialogueSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            _checkTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _checkTrigger = false;
        }
    }

    private void Update()
    {
        if (_checkTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _dialogueSystem.StopAllCoroutines();
                _dialogueSystem.StartDialogue(_dialogueText);
            }
        }
    }
}
