using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private GameObject _dialoguePanel;
    [SerializeField] private TextMeshProUGUI _tmpro;
    [SerializeField] private float _textSpeed;

    public bool _checkContinuePressButton;
    public bool _checkKeyEPress = true;

    private void Start()
    {
        _dialoguePanel.SetActive(false);
    }

    public void StartDialogue(List<string> dialogueText)
    {
        StartCoroutine(OutputText(dialogueText));
    }

    IEnumerator OutputText(List<string> dialogueText)
    {
        _checkKeyEPress = true;
        _tmpro.text = "";
        _dialoguePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        foreach (string phrase in dialogueText)
        {
            foreach (char symbol in phrase)
            {
                _tmpro.text += symbol.ToString();
                yield return new WaitForSeconds(_textSpeed);
            }

            yield return new WaitUntil(() => _checkContinuePressButton == true);
            _tmpro.text = "";
            _checkContinuePressButton = false;
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _dialoguePanel.SetActive(false);
        _checkKeyEPress = false;
    }

    public void ButtonDownNextPhrase()
    {
        _checkContinuePressButton = true;
    }
}
