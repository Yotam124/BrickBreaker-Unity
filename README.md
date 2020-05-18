# # Gamedev-08-q7
Contains the 7 question (Physical engine and levels design): gamedev-5780

Created by:

**Yotam dafna**

**Tomer hazan**

# Game description: 

* Brick Breaker Game, the player needs to break all the bricks to pass through levels.

* The player should aim the plate so that the ball hits the bricks and breaks them.

* The player start with 3 lives and every time the ball reach the bottom the player will start again the level and the life will go down by 1.

* Game Over - when the lives run out.

* **picture of the game**

# The Player

Keyboards and Movement:

* The player controls the plate by clicking and dragging the mouse and decides which direction in the X-axis it will move (left or right).

* space key - Release the ball up.

Boundries:

* The player cant get out from the screen (Right or Left).

Player Collision:

* Extra life - If the player break a brick there is a chance that extra life will fall down from the brick, if the player will collect him, he will get extra life.

* **picture of the extra life**

* Ball - if the ball hits the player(plate) the ball will fly in a certain direction.

# The Ball

Ball Collision:

* With Botton - if the ball reachs the bottom he will rebooted to player position.

* With Brick - the brick life points will go by 1.

* With Boundries - the ball will fly in a certain direction.

Boundries:

* The Ball cant get out from the screen boundaries(left,right,top)

# Bricks

Every brick as life points of its own that if they go down to 0, the brick will will explode.

There are 2 types of bricks - "brick", and "last brick":

* brick - if the player will destroy the brick, another brick will showed up with different color, and if the second brick will expload - the "last brick" will showed up in a different color.

* last brick - if the player will destroy the last brick he will get 1 points to the score.

# Levels

* The game has 3 different levels.

# Canvas

When the player is playing, the score and the life points will be presented to the player in the screen.

Panels - the game has 3 different panels:

* Start Game - the first panel that the player will see at the start of the game(buttons - Start Game or Quit).

* Load Level - the player will see the panel (the next level - "level X") for 3 seconds after pass the level.

* Game Over - after the amount of lives will fall down to 0 the player will see the Game Over panel (buttons - Play Again or Quit)

# Game Manager

* Restart level
```
private void RestartLevel(){

        Destroy(GameObject.FindWithTag("level"));
        Instantiate(levels[currLevelIndex], Vector2.zero, Quaternion.identity);
        numberOfBricks = totalLvlBricks;
        gameOver = false;
    }

```

* Update score (when the player will get points)

```
    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

```

# Link to ITCH.IO

[Brick Breaker Game](https://yotamd.itch.io/brickbreaker)


