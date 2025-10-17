using System;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;

public class Program
{
    // Keypad map for displaying the current character being typed
    // for visual feedback to the user, not directly used by the solver.
    private static readonly Dictionary<char, string> DisplayKeypadMap = new Dictionary<char, string>
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

    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Old Phone Pad Input Simulator!");
        Console.WriteLine("Enter keys (0-9, *, #). Enter '#' to send/finish.");
        Console.WriteLine("A space will be inserted in the raw input if you pause for 1 second between same key presses, or press a different key.");
        Console.WriteLine("-----------------------------------------------------------------------------");

        // rawInputBuilder: This string is what will actually be passed to OldPhonePadSolver.
        // It includes spaces for pauses and different keys.
        StringBuilder rawInputBuilder = new StringBuilder();

        // currentTypingSequence: This temporarily holds the sequence of identical key presses
        // before they are committed to rawInputBuilder (e.g., "4", then "44", then "444").
        StringBuilder currentTypingSequence = new StringBuilder();

        // stopwatch: Used to measure the time between key presses.
        Stopwatch stopwatch = new Stopwatch();

        // lastKeyInCurrentSequence: The character that is currently being typed in currentTypingSequence.
        char? lastKeyInCurrentSequence = null;

        // Display loop continues until '#' is pressed
        while (true)
        {
            // Clear current line and re-display information to keep the console clean
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth)); 
            Console.SetCursorPosition(0, Console.CursorTop);

            // Display the raw input string being built
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Raw Input (to solver): {rawInputBuilder.ToString()}{currentTypingSequence.ToString()}");
            Console.ResetColor();

            // Decode and display the current output based on the raw input
            string currentDecodedOutput = OldPhonePadSolver.OldPhonePad(rawInputBuilder.ToString() + currentTypingSequence.ToString());
            Console.WriteLine($"\nDecoded Output: {currentDecodedOutput}");

            Console.Write("Enter your keypad number: ");

            // Start or restart the stopwatch for timing the pause before the next key press
            stopwatch.Restart();

            // Read key without displaying it immediately
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            char inputChar = keyInfo.KeyChar;

            // Stop the stopwatch immediately after reading the key
            stopwatch.Stop();
            double elapsedSeconds = stopwatch.Elapsed.TotalSeconds;

            // Handle special keys first: '#' (Send) and '*' (Backspace)
            if (inputChar == '#')
            {
                // If there's an uncommitted sequence, commit it before sending
                if (currentTypingSequence.Length > 0)
                {
                    rawInputBuilder.Append(currentTypingSequence.ToString());
                }
                rawInputBuilder.Append('#');
                Console.WriteLine("\nSending message...");
                break; // Exit the main input loop
            }
            else if (inputChar == '*')
            {
                // If there's an uncommitted sequence, commit it before backspacing
                if (currentTypingSequence.Length > 0)
                {
                    rawInputBuilder.Append(currentTypingSequence.ToString());
                    currentTypingSequence.Clear();
                    lastKeyInCurrentSequence = null;
                }
                rawInputBuilder.Append('*');
            }
            // Handle digit presses (0-9)
            else if (char.IsDigit(inputChar))
            {
                // Case 1: Starting a new sequence (first digit, or after a special key/pause)
                // Case 2: Continuing the same sequence (same digit, within 1 second)
                if (currentTypingSequence.Length == 0 || 
                    (inputChar == lastKeyInCurrentSequence && elapsedSeconds < 1.0))
                {
                    currentTypingSequence.Append(inputChar);
                    lastKeyInCurrentSequence = inputChar;
                }
                // Case 3: Different digit pressed, or same digit but after a pause (>= 1 second)
                else 
                {
                    // Commit the previous sequence to rawInputBuilder
                    if (currentTypingSequence.Length > 0)
                    {
                        rawInputBuilder.Append(currentTypingSequence.ToString());
                    }
                    rawInputBuilder.Append(' '); // Insert a space as a delimiter
                    
                    // Start a new sequence with the current inputChar
                    currentTypingSequence.Clear();
                    currentTypingSequence.Append(inputChar);
                    lastKeyInCurrentSequence = inputChar;
                }
            }
            // Handle explicit space input from the user (acts as an immediate pause)
            else if (inputChar == ' ')
            {
                // Commit the previous sequence to rawInputBuilder
                if (currentTypingSequence.Length > 0)
                {
                    rawInputBuilder.Append(currentTypingSequence.ToString());
                    currentTypingSequence.Clear();
                    lastKeyInCurrentSequence = null;
                }
                rawInputBuilder.Append(' '); // Append the explicit space
            }
            // Other characters are ignored
        }

        // After the loop, display final results
        Console.WriteLine("-----------------------------------------------------------------------------");
        Console.WriteLine($"Final Raw Input String: {rawInputBuilder.ToString()}");
        Console.WriteLine($"Final Decoded Message: {OldPhonePadSolver.OldPhonePad(rawInputBuilder.ToString())}");
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
