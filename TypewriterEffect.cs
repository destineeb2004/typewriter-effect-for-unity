using System.Collections;
using TMPro;
using UnityEngine;

public class TypewriterEffect : MonoBehaviour
{
    public TMP_Text dialogueText;
    public float typingSpeed = 0.1f;
    public float timeBetweenSpecials = 0.4f;

    void Start()
    {
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        var specials = ".,?!";

        dialogueText.maxVisibleCharacters = 0;

        var lastLetterOfText = dialogueText.text.ToCharArray()[dialogueText.text.Length - 1];

        foreach (char letter in dialogueText.text.ToCharArray())
        {
            if (specials.Contains(letter) && letter != lastLetterOfText)
            {
                dialogueText.maxVisibleCharacters++;
                yield return new WaitForSeconds(timeBetweenSpecials);
            } else
            {
                dialogueText.maxVisibleCharacters++;
                yield return new WaitForSeconds(typingSpeed);
            }
            
        }

        yield break;
    }
    
}
