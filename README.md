# flappybird

Flappy Bird is a classic arcade game built using C# and Windows Forms. The game features a bird that the player controls to navigate through pipes. The objective is to keep the bird flying and avoid colliding with the pipes. The player gains a point every time the pipes move off-screen and reappear.

## Features
- **Bird Movement**: The bird moves upward when the spacebar is pressed and falls due to gravity when it's released.
- **Pipes**: Randomly generated top and bottom pipes that move from right to left across the screen.
- **Score**: The score increases every time the pipes pass the screen.
- **Game Over**: The game ends if the bird collides with the pipes or the top or bottom of the screen.
- **Resume Button**: After the game ends, the player can click the "Resume Game" button to restart the game.

## Requirements
- .NET Framework 4.7.2 or higher
- Visual Studio 2019 or higher

## How to Run

1. Clone this repository to your local machine.
2. Open the solution file (`FlappyBird.sln`) in Visual Studio.
3. Build and run the project.
4. The game window will appear. Press the **Spacebar** to make the bird fly and avoid the pipes.
5. When the game ends, click the "Resume Game" button to restart the game.

## Controls
- **Spacebar**: Makes the bird fly upwards.
- **Click "Resume Game"**: Resumes the game after it ends.

## Game Over Conditions
- The bird collides with either the top or bottom pipes.
- The bird touches the top or bottom of the screen.



