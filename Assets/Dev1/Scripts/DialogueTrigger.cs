using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueSystem _dialogueSystem;

    [SerializeField] private List<string> _dialogueText;

    private void Start()
    {
        _dialogueSystem = FindObjectOfType<DialogueSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            _dialogueSystem.StartDialogue(_dialogueText);
        }
    }
}
