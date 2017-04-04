using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    public GUIText Timer;//How we display score
    public GUIText GameState;//How we display text for gameover/win
    public GameObject background;
    public GameObject player;
    public GameObject AnythingThatRewinds;
    public GameObject RewindSlider;
    public int time = 18000;//Frames in 5 minutes
    
    bool rewind = false;
    public string NameOfNextLevel = "level1";

    //bool spawn = true;
    // Use this for initialization
    void Start()
    {
        //script = GameObject.Find("Player").GetComponent<ScriptType>();

    }

    // Update is called once per frame
    void Update()
    {
        //RewindSlider.GetComponent<Slider>().value = AnythingThatRewinds.GetComponent<Pong>().rewindPositions.Count;
        if (time > 0 && !player.GetComponent<PlayerScript>().win && !player.GetComponent<PlayerScript>().lost)
        {
            RewindSlider.GetComponent<Slider>().value = AnythingThatRewinds.GetComponent<Pong>().posInArray;
        }else
        {
            Destroy(RewindSlider);
        }
        if (AnythingThatRewinds.GetComponent<Pong>().rewind)//Remember, pong is just a generic rewindpos script
        {
            time++;
            if(background.GetComponent<AudioSource>().pitch == 1)
            {
                background.GetComponent<AudioSource>().pitch = -1;
            }
        }
        else
        {
            time--;
            if (background.GetComponent<AudioSource>().pitch == -1)
            {
                background.GetComponent<AudioSource>().pitch = 1;
            }
        }


        if (player.GetComponent<PlayerScript>().win) {
            background.GetComponent<SpriteRenderer>().sortingOrder = 5;
            GameState.text = "Nice job! \n Press Space to go to the next level";
            if (Input.GetKeyDown(KeyCode.Space))//Restart code
            {
                SceneManager.LoadScene(NameOfNextLevel, LoadSceneMode.Single);
            }
        }
        if (player.GetComponent<PlayerScript>().lost)
        {
            background.GetComponent<SpriteRenderer>().sortingOrder = 5;
            GameState.text = "Nice try! \n Press Space to go to try again";
           
                background.GetComponent<AudioSource>().pitch = 0;
            
            if (Input.GetKeyDown(KeyCode.Space))//Restart code
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//This is just saying "Hey, reload that scene!" and thus does all the heavy lifting
            }
           
        }
        if (!player.GetComponent<PlayerScript>().win && !player.GetComponent<PlayerScript>().lost) { 
        Timer.text = time / 3600 + ":" + (time / 60) % 60;
        if (Timer.text.Length == 3) { Timer.text = Timer.text.Substring(0, 2) + "0" + Timer.text.Substring(2); }
        }
        else
        {
            Timer.text = "";

        }
        if (time <= 0 && !player.GetComponent<PlayerScript>().win && !player.GetComponent<PlayerScript>().lost) {
            background.GetComponent<SpriteRenderer>().sortingOrder = 5;
            GameState.text = "Time's up! \n Press Space to try again";
            if (Input.GetKeyDown(KeyCode.Space))//Restart code
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//This is just saying "Hey, reload that scene!" and thus does all the heavy lifting
            }
        }

        /*if (GameOver)//Game Over
        {
            background.GetComponent<SpriteRenderer>().sortingOrder = 5;
            if (Input.GetKeyDown(KeyCode.R))//Restart code
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//This is just saying "Hey, reload that scene!" and thus does all the heavy lifting
            }
            //GameOver.GetComponent<Transform>().position = new Vector3(.5f, .5f, 0);
            GameOver.transform.position = new Vector3(.5f, .5f, 0);
        }*/
    }


    
    /*void spawnWaves()
    {

        for (float q = 0; q < 6; q += 1.2f)//Nested for loop for a grid structure
        {
            for (int i = -4; i < 5; i++)
            {
                Instantiate(enemySpaceship, new Vector3(10 + q, i, 0), transform.rotation);//Makes the enemies from the prefab.
                                                                                           //enemyCount++;
            }*
        }

    }*/
}