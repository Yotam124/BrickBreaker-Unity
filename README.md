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

![WhatsApp Image 2020-05-18 at 15 24 24](https://user-images.githubusercontent.com/45067010/82213265-8c49c400-991c-11ea-8daa-29b092ae85c4.jpeg)

# The Player

Keyboards and Movement:

* The player controls the plate by clicking and dragging the mouse and decides which direction in the X-axis it will move (left or right).

* space key - Release the ball up.

Boundries:

* The player cant get out from the screen (Right or Left).

Player Collision:

* Extra life - If the player break a brick there is a chance that extra life will fall down from the brick, if the player will collect him, he will get extra life (animation in "Bricks");

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
 
 animations (expload last brick and extra life):
 
 ![WhatsApp Image 2020-05-18 at 15 24 24 (1)](https://user-images.githubusercontent.com/45067010/82213078-412fb100-991c-11ea-8d4b-81bfa3a82b45.jpeg)

# Levels

* The game has 3 different levels.

* level 1 - the first picture.

* level 2:

![Untitled](https://user-images.githubusercontent.com/45067010/82213617-2578da80-991d-11ea-990d-13e6e6656693.png)

* level 3:

![Untitle1d](https://user-images.githubusercontent.com/45067010/82213745-548f4c00-991d-11ea-8ae3-35c587e1bba2.png)

# Canvas

When the player is playing, the score and the life points will be presented to the player in the screen.

Panels - the game has 3 different panels:

* Start Game - the first panel that the player will see at the start of the game(buttons - Start Game or Quit).

![Untitle222d](https://user-images.githubusercontent.com/45067010/82214390-6de4c800-991e-11ea-9761-ac8eacd888a8.png)

* Load Level - the player will see the panel (the next level - "level X") for 3 seconds after pass the level.

![Unti11tled](https://user-images.githubusercontent.com/45067010/82214413-76d59980-991e-11ea-935e-667f146eb26d.png)

* Game Over - after the amount of lives will fall down to 0 the player will see the Game Over panel (buttons - Play Again or Quit)

![1Untitled](https://user-images.githubusercontent.com/45067010/82214356-5efe1580-991e-11ea-9c35-24bd73fc6c1f.png)


# Game Manager

* parameters:
```
public class GameManager : MonoBehaviour
{
    public int lives;                           // keeps the number of life points that the player have.
    public int score;                           // keeps the total score.
    public Text livesText;                      // life points in canvas.
    public Text scoreText;                      // score in canvasa.
    public bool gameOver;                       // boolean parameter if the game is over or not.
    public GameObject gameOverPanel;            // the game over panel (Turn on or off).
    public GameObject loadLevelPanel;           // the load game panel (Turn on or off).
    public int numberOfBricks;                  // keeps the numbers of bricks that the player needs to destroy.
    public Transform[] levels;                  // keeps the levels.
    public int currLevelIndex = 0;              // keeps the current level index.
    public Ball ball;                           // ball object
    private int totalLvlBricks;                 // keeps the total bricks of the current level
}
```
* Start function
```
    void Start()
    {
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        numberOfBricks = GameObject.FindGameObjectsWithTag("brick").Length + GameObject.FindGameObjectsWithTag("last brick").Length;
        totalLvlBricks = numberOfBricks;
    }

```

* Update lives function
```
public void UpdateLives(int changeInLives)
    {
        lives += changeInLives;

        //check for no lives left and trigger the end of the game
        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }
        else if (changeInLives < 0)
        {
            RestartLevel();
        }

        livesText.text = "Lives: " + lives;
    }

```

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

* UpdateNumOfBricks and go to next level

```
    public void UpdateNumOfBricks()
    {
        numberOfBricks--;
        if (numberOfBricks <= 0)
        {
            if (currLevelIndex >= levels.Length - 1)
            {
                GameOver();
            }
            else // next level
            {
                loadLevelPanel.SetActive(true);
                loadLevelPanel.GetComponentInChildren<Text>().text = "Level " + (currLevelIndex +2);
                gameOver = true;
                ball.newLevel();
                Invoke("LoadLevel" , 3f);
            }
        }
    }

```

* GameOver function

```
        void GameOver()
    {
        gameOver = true;
        ball.newLevel();
        gameOverPanel.SetActive(true);
    }

```

* Play again function

```
public void PlayAgain()
    {
        SceneManager.LoadScene("MainScene");
    }

```

* Quit function

```
public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }

```

# Link to ITCH.IO

[Brick Breaker Game](https://yotamd.itch.io/brickbreaker)


