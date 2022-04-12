using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerTyping : MonoBehaviour
{
    public static PlayerTyping _pTyping { get; private set; }

    [SerializeField]
    private bool playerCanType = false;

    public bool PlayerCanType { get { return playerCanType; }set { playerCanType = value; }  }

    public HackerTextBank textBank = null;
    public TextMeshProUGUI baseWordText = null;
    public TextMeshProUGUI completeWordText = null;

    string baseWord = string.Empty;
    string completeWord = string.Empty;

    int pos;

    private void Awake()
    {
        _pTyping = this;
    }

    private void Start()
    {
        InitializeFirstRun();
    }

    void InitializeFirstRun()
    {
        pos = 0;
        baseWord = GetNewWord();
        UpdateBaseStringUI(baseWord);
    }

    void ReInitialize()
    {
        pos = 0;
        baseWord = GetNewWord();
        UpdateBaseStringUI(baseWord);
        completeWord = string.Empty;
        UpdateCompleteStringUI(string.Empty);
    }

    private void Update()
    {
        CheckInput();
    }

    void CheckInput()
    {
        if (Input.anyKeyDown && playerCanType)
        {
            string input = Input.inputString;

            if (input.Length == 1) ValidateInput(input);
        }
    }

    void ValidateInput(string input)
    {
        if(input[0] == baseWord[pos])
        {
            BuildNewString(input[0]);
            pos++;
        }

        if (CheckCompletion()) ReInitialize();
    }

    bool CheckCompletion()
    {
        // We are at the end of the word if the position is equal to the length of the base word
        return pos == baseWord.Length;
    }

    void BuildNewString(char input)
    {
        completeWord = completeWord + input;
        UpdateCompleteStringUI(completeWord);
    }

    void UpdateBaseStringUI(string newText)
    {
        baseWordText.text = newText;
    }

    void UpdateCompleteStringUI(string newText)
    {
        completeWordText.text = newText;
    }

    string GetNewWord()
    {
        return textBank.GetWord();
    }

    #region OLD CODE

    /*
    string remainingWord = string.Empty;
    string wordInProgress = string.Empty;
    string currentWord = string.Empty;

    int wordProgress = 0;
    int wordTotal;

    void Start()
    {
        SetCurrentWord();
    }

    void SetCurrentWord()
    {
        currentWord = textBank.GetWord();
        wordInProgress = string.Empty;
        remainingWord = currentWord;
        ResetWordProgress();
        UpdateWordText(currentWord);
    }

    void ResetWordProgress()
    {
        wordProgress = 0;
        wordTotal = currentWord.Length;
    }

    void BuildColoredWord(string colorLetter)
    {
        wordInProgress = wordInProgress + colorLetter;
        string finishedWord = wordInProgress + remainingWord.Remove(0, wordProgress);
        UpdateWordText(finishedWord);
    }

    void UpdateWordText(string newText)
    {
        wordText.text = newText;
    }

    void SetRemainingWord(string newWord)
    {
        wordInProgress += newWord;
        string firstPart = wordInProgress + newWord;
        string secondPart = remainingWord.Remove(0, wordProgress);
        wordText.text = firstPart + secondPart;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    void CheckInput()
    {
        if (Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;

            if(keysPressed.Length  == 1)
            {
                EnterLetter(keysPressed);
            }
        }
    }

    void EnterLetter(string typedLetter)
    {
        if (IsCorrectLetter(typedLetter))
        {
            // Increment WordProgress to keep us on track as we travel through the current word
            wordProgress++;

            // Color the letter green instead of removing and leave whole word intact
            for(int i = 0; i < remainingWord.Length; i++)
            {
                if (typedLetter[0] == remainingWord[i])
                {
                    ColorLetter(typedLetter);
                    break;
                }
            }

            // Check if we've typed out the entire word (wordProgress variable is equal to amount of characters in word)
            if (IsWordComplete()) SetCurrentWord();
        }
    }

    bool IsCorrectLetter(string letter)
    {
        // Always look for the index starting from the last index we were at prior to the most recent keypress
        // We will use the wordProgress variable (which keeps track of how far along you are in a current word, conveniently this works as an index too)
        return remainingWord.IndexOf(letter, wordProgress) == wordProgress;
    }

    bool IsWordComplete() // <3
    {
        return wordProgress == wordTotal;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="letter"></param>
    void ColorLetter(string letter)
    {
        string coloredChar = "<color=green>" + letter + "</color>";
        BuildColoredWord(coloredChar);
    }*/
    #endregion
}