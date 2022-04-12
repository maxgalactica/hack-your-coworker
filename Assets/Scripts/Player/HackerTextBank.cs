using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackerTextBank : MonoBehaviour
{

    List<string> startingWords = new List<string>()
    {
        "sally mae", "beeg yoshi", "vacuum cleaner", "brrrrdddddppppp", "hurr durr"
    };

    List<string> playingWords = new List<string>();

    private void Awake()
    {
        playingWords.AddRange(startingWords);
        Shuffle(playingWords);
        ConvertToLower(playingWords);
    }

    void Shuffle(List<string> wordlist)
    {
        for(int i = 0; i < wordlist.Count; i ++)
        {
            int random = Random.Range(i, wordlist.Count);
            string temp = wordlist[i];

            wordlist[i] = wordlist[random];
            wordlist[random] = temp;
        }
    }

    void ConvertToLower(List<string> wordList)
    {
        for(int i = 0; i < wordList.Count; i++)
        {
            wordList[i] = wordList[i].ToLower();
        }
    }

    public string GetWord()
    {
        string newWord = string.Empty;

        if(playingWords.Count != 0)
        {
            newWord = playingWords.Last();
            playingWords.Remove(newWord);
        }

        return newWord;
    }
}
