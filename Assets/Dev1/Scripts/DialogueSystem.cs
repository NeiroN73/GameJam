using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    private TextMeshProUGUI _tmpro;
    [SerializeField] private float _textSpeed;

    public void StartDialogue(List<string> dialogueText)
    {
        StartCoroutine(OutputText(dialogueText));
    }

    IEnumerator OutputText(List<string> dialogueText)
    {
        foreach (char symbol in dialogueText[0])
        {
            _tmpro.text += symbol.ToString();
            yield return new WaitForSeconds(_textSpeed);
        }
    }
}
