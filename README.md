# Game Title: 2D-Adventure

## Introduction

Welcome to **2D-Adventure**! This is a 2D platformer game where players navigate through levels filled with challenges, collect items, and race against the clock to achieve the best completion times.

## Installation

1. Clone the repository or download the zip file.
2. Open the project in Unity.
3. Ensure you have the necessary Unity version installed (e.g., Unity 2022.3.46f1).
4. Open the scene named **UserEntry** to start playing.
5. Press the play button in Unity to test the game.

## Gameplay

### Objective
The main objective of the game is to complete each level as quickly as possible while overcoming obstacles and collecting power-ups. Players aim to achieve the fastest time to climb the leaderboard.

### Controls
- **Movement:** 
  - **Left Arrow / A:** Move left
  - **Right Arrow / D:** Move right
  - **Up Arrow / W:** Jump
  - **Space (Hold):** Attack
- **Pause:** 
  - **Escape:** Open the pause menu

### Game Mechanics
- **Levels:** Navigate through different levels, each with unique challenges and enemies.
- **Collectibles:** Gather items to gain power-ups or points:
  - **Coins:** Gain Points.
  - **Health:** Restores player health.
  - **Jumper:** Allows the player to jump three times (single use).
- **Timer:** The timer starts when the level begins and stops upon completing the Game.
- **Death and Respawn:** Players can respawn at checkpoints(Level) if they lose a life with **level automatically reset time of 3 seconds**.
- **Leaderboard:** Players can view their completion times and compare them with others.

## Features
- **Two Levels:** Currently includes two playable levels with increasing difficulty.
- **Health System:** Players and enemies share a health functionality with power-up like health regeneration.
- **Power-Ups:** Collect Health power-ups to restore health and Jumper power-ups to gain a third jump (single use).
- **Leaderboard System:** Displays the top three scores based on completion time.
- **Level reset:** Level automatically resets after 3 seconds of dying.
- **Sound Effects:** Includes sound effects for actions like jumping, collecting items, and level completion.

## Leaderboard

The leaderboard tracks the fastest completion times for players. It shows the username and time taken to complete each level. Players must enter their username at the start of the game to have their scores recorded.

### How to View the Leaderboard
1. Click on the **Leaderboard** button in the main menu.
2. The leaderboard panel will display the top entries.
3. Click the **Clear** button in the leaderboard panel to remove old leaderboard records.
4. Close the leaderboard panel by clicking the **Close** button.

## Asset References

- **Adventurer Asset:** https://rvros.itch.io/animated-pixel-hero
- **Pixelart Platformer Tileset:** https://aamatniekss.itch.io/free-pixelart-platformer-tileset
- **Audio:** https://mixkit.co/free-sound-effects/
