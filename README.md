# -Mastermind-Console-Game

This project is a console-based implementation of the classic **Mastermind** game, developed in **C#** using object-oriented programming principles. It was built as part of the **Gameplay Programming Track Skills Assessment** for the 2025 Steer Elite Internship Program.

## 🎮 Game Description

**Mastermind** is a code-breaking game in which:
- The computer selects a secret 4-digit code using distinct digits between `0` and `7`.
- The player has a limited number of attempts (default: 10) to guess the code.
- After each guess, the game returns:
  - `Well placed pieces`: digits that are correct and in the correct position.
  - `Misplaced pieces`: digits that are correct but in the wrong position.
- The player wins if they guess the code within the allowed attempts.

Example:
Can you break the code? Enter a valid guess.
1234
Well placed pieces: 1
Misplaced pieces: 2


## ⚙️ Features

- Clean and professional **object-oriented structure**
- Accepts **command-line arguments**:
  - `-c [CODE]`: define the secret code manually (must be 4 unique digits from 0–7)
  - `-t [ATTEMPTS]`: set a custom number of allowed attempts
- Handles **invalid inputs** with friendly messages
- Gracefully exits on **Ctrl+D / EOF**
- Random code generation when no `-c` is provided
- Clear feedback after each guess
- Displays a congratulatory message on success

## 🧑‍💻 How to Run

1. Compile the project using any C# compiler (e.g., `dotnet` or Visual Studio).
2. From the terminal, run the executable:



## 🛠️ Technologies

- Language: **C#**
- Framework: **.NET Console App**
- Programming Concepts: Classes, Encapsulation, Loops, Conditionals, Arrays, Input Validation


## 🧠 What I Learned

- How to structure a game using clean OOP principles
- Managing input validation in a console environment
- Parsing command-line arguments in C#
- Implementing game logic using arrays and state tracking
- Communicating results clearly to the user

- 
## 👤 Author

**Rayan Mandili**  
Computer Science Graduate | Aspiring Gameplay Programmer  
Languages: C#, C++  
Engines: Unity, Unreal Engine  
Soft Skills: Teamwork, Creativity, Communication

## 📝 License

This project is submitted as part of an assessment and is intended for educational and demonstration purposes only.







نسخ
تحرير

