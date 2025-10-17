using System;
using System.Text;
using System.Collections.Generic;

// This class contains the core logic to decode an PhonePad input string
public static class OldPhonePadSolver
{
    // A dictionary to map numbers to their corresponding characters
    private static readonly Dictionary<char, string> KeypadMap = new Dictionary<char, string>
    {
        { '1', "&'(" },
        { '2', "ABC" },
        { '3', "DEF" },
        { '4', "GHI" },
        { '5', "JKL" },
        { '6', "MNO" },
        { '7', "PQRS" },
        { '8', "TUV" },
        { '9', "WXYZ" },
        { '0', " " }
    };

    /// <summary>
    /// Decodes a string representing old phone pad presses into the corresponding text.
    /// The input string may contain spaces (' ') to indicate pauses, '*' for backspace, and '#' to end.
    /// </summary>
    /// <param name="input">The raw input string constructed from user presses, including spaces for pauses.</param>
    /// <returns>The decoded string.</returns>
    public static string OldPhonePad(string input)
    {
        StringBuilder result = new StringBuilder();
        char? lastChar = null; // Stores the last digit key that was pressed
        int pressCount = 0;    // Stores how many times the lastChar was pressed in succession

        foreach (char c in input)
        {
            if (c == '#')
            {
                // Process any pending sequence before ending the input
                if (lastChar.HasValue && pressCount > 0 && KeypadMap.ContainsKey(lastChar.Value))
                {
                    string chars = KeypadMap[lastChar.Value];
                    result.Append(chars[(pressCount - 1) % chars.Length]);
                }
                break;
            }

            if (c == '*') // Backspace operation
            {
                // Process any pending sequence first, then perform backspace
                if (lastChar.HasValue && pressCount > 0 && KeypadMap.ContainsKey(lastChar.Value))
                {
                    string chars = KeypadMap[lastChar.Value];
                    result.Append(chars[(pressCount - 1) % chars.Length]);
                }

                if (result.Length > 0)
                {
                    result.Remove(result.Length - 1, 1);
                }
                // Reset state after backspace as it breaks any ongoing sequence
                lastChar = null;
                pressCount = 0;
                continue;
            }

            if (c == ' ') // Pause indicator (inserted by interactive input)
            {
                // A space means the previous sequence of presses is complete
                if (lastChar.HasValue && pressCount > 0 && KeypadMap.ContainsKey(lastChar.Value))
                {
                    string chars = KeypadMap[lastChar.Value];
                    result.Append(chars[(pressCount - 1) % chars.Length]);
                }
                // Reset for a new sequence after the pause
                lastChar = null;
                pressCount = 0;
                continue;
            }

            // Handle regular digit button presses
            if (c == lastChar)
            {
                // Same character pressed again, continue the sequence
                pressCount++;
            }
            else
            {
                // A new character is pressed or it's the first character of a sequence
                // First, process any completed sequence from the previous 'lastChar'
                if (lastChar.HasValue && pressCount > 0 && KeypadMap.ContainsKey(lastChar.Value))
                {
                    string chars = KeypadMap[lastChar.Value];
                    result.Append(chars[(pressCount - 1) % chars.Length]);
                }
                // Start a new sequence with the current character
                lastChar = c;
                pressCount = 1;
            }
        }

        return result.ToString();
    }
}
