using System;

public class Counter()
{
    string path = "C:\\Users\\Kendra\\Desktop\\foldertoread\\file1.txt";

    public void CountLines()
    {
        int linesCounter = 0;
        var lines = File.ReadLines(path);

        foreach (var line in lines)
        {
            linesCounter++;
        }
        Console.WriteLine($"The amount of lines were: {linesCounter}");
    }

    public void CountWords()
    {
        int wordsCounter = 0;
        var lines = File.ReadLines(path);
        List<string> wordsList = new List<string>();

        foreach (var line in lines)
        {
            var words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries); //Remove the spaces
            wordsList.AddRange(words); //Add the words to the list
            wordsCounter += words.Length; //Increment word count
        }
        Console.WriteLine($"The amount of words were: {wordsCounter}");
    }
    public void CountChars()
    {
        var characters = File.ReadAllText(path);
        int characterCounter = 0;
        //int insideForEach = 0;
        int spacesCount = 0;
        int separatorCounts = 0;

        foreach (var character in characters) //In C#, when you iterate a string with a foreach, it will check character by character. Meaning that the if statements below should be in char format.
        {
            characterCounter++;
            if (character == ' ')
            {
                characterCounter--;
                spacesCount++;
            }

            if (character == '\r')
            {
                characterCounter--;
                separatorCounts++;

            }

            if (character == '\n')
            {
                characterCounter--;
                separatorCounts++;
            }

            //insideForEach++;
        }
        Console.WriteLine($"The amount of characters were: {characterCounter}. Amount of spaces present {spacesCount}. Amount of line breaks present: {separatorCounts}");
        //Console.WriteLine($"Inside for each: {insideForEach}");

    }
}
