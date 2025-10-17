# Old Phone Pad C# Coding Challenge

This project implements a solution for the "Old Phone Pad" coding challenge, which involves converting sequences of key presses from a traditional mobile phone keypad into text.

## Challenge Description

The core challenge is to simulate an old phone keypad where pressing a button multiple times cycles through letters. Key features include:
-   Multiple presses on the same key for different letters (e.g., '2' once for 'A', twice for 'B').
-   A conceptual "pause" represented by a space character in the input, signaling the end of a sequence of presses for a single key.
-   A backspace key (`*`) to delete the last character.
-   A send key (`#`) to finalize the input.

This implementation includes an interactive console application that simulates user input, tracks time between key presses, and automatically inserts pauses (spaces) into the raw input string based on user behavior.

## Features

*   **Interactive Input:** Prompts the user to enter keypad numbers (0-9), `*` for backspace, and `#` to send.
*   **Time-Based Pauses:** Automatically inserts a space into the raw input if the user pauses for 1 second or more between presses of the *same* key.
*   **Key Change Pauses:** Automatically inserts a space if a different key is pressed, signaling a new character sequence.
*   **Real-time Decoding:** Displays the current raw input and decoded output as the user types.
*   **Modular Design:** Separates the core decoding logic (`OldPhonePadSolver.cs`) from the interactive input handling (`Program.cs`).

## How to Run

1.  **Prerequisites:** Ensure you have the .NET SDK (version 9.0 or later recommended) installed.
2.  **Clone the repository:**
    ```bash
    git clone https://github.com/ImUlyssus/OldPhonePadChallenge.git
    cd OldPhonePadChallenge
    ```

3.  **Navigate to the project directory:**
    ```bash
    cd OldPhonePadChallenge # This is the nested project folder containing the .csproj
    ```
4.  **Run the application:**
    ```bash
    dotnet run
    ```
5.  Follow the prompts in the console to enter your keypad sequence.

## How to Run Tests

1.  **Prerequisites:** Ensure you have the .NET SDK (version 9.0 or later recommended) installed.
2.  **Clone the repository:** (If you haven't already)
    ```bash
    git clone https://github.com/ImUlyssus/OldPhonePadChallenge.git
    cd OldPhonePadChallenge
    ```
3.  **Navigate to the solution root directory:**
    ```bash
    # You should be in the directory containing OldPhonePadChallenge.sln
    # If you are in the nested project folder, use:
    # cd ..
    ```
4.  **Run all tests:**
    ```bash
    dotnet test
    ```
    This will build and execute all tests in the `OldPhonePadChallenge.Tests` project.

## Example Usage
Welcome to the Old Phone Pad Input Simulator!
Enter keys (0–9, *, #)
- Use '*' for backspace
- Use '#' to send/finish
- A space is automatically inserted if you pause for 1s or press a different key

Enter your keypad number: 4
Raw Input (to solver): 4
Decoded Output: G

Enter your keypad number: 4 (quickly)
Raw Input (to solver): 44
Decoded Output: H

Enter your keypad number: 3 (different key)
Raw Input (to solver): 44 3
Decoded Output: HD

Enter your keypad number: 3 (quickly)
Raw Input (to solver): 44 33
Decoded Output: HE

Enter your keypad number: 5 (wait >1s)
Raw Input (to solver): 44 33 5
Decoded Output: HEL

Enter your keypad number: 5 (quickly)
Raw Input (to solver): 44 33 55
Decoded Output: HELL

Enter your keypad number: 5 (quickly)
Raw Input (to solver): 44 33 555
Decoded Output: HELLO

Enter your keypad number: #
Sending message...

Final Raw Input String: 44 33 555#
Final Decoded Message: HELLO

Press any key to exit.



## Project Structure

*   `OldPhonePadChallenge.sln`: The solution file.
*   `OldPhonePadChallenge/`: The main project folder.
    *   `OldPhonePadChallenge.csproj`: Project definition file.
    *   `Program.cs`: Contains the `Main` method for interactive user input, time tracking, and constructing the raw input string.
    *   `OldPhonePadSolver.cs`: Contains the `OldPhonePad` static method, which holds the core logic for decoding a given input string.

## Author

Kyaw Swar Hein