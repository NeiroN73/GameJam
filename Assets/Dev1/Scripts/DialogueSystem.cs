using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    private TextMeshProUGUI _tmpro;
    [SerializeField] private float _textSpeed;

    private bool check;

    public void StartDialogue(List<string> dialogueText)
    {
        StartCoroutine(OutputText(dialogueText));
    }

    IEnumerator OutputText(List<string> dialogueText)
    {
        foreach (string phrase in dialogueText)
        {
            foreach (char symbol in phrase)
            {
                //_tmpro.text += symbol.ToString();
                print(symbol.ToString());
                yield return new WaitForSeconds(_textSpeed);
            }

            yield return new WaitUntil(() => check == true);
        }
    }

    public void ButtonDownNextPhrase()
    {
        check = true;
    }

    public void ButtonUpNextPhrase()
    {
        check = false;
    }
}
