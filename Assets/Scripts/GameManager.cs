using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public enum States { MENU, PLAYING, PAUSED, DEAD, QUIT };
    
    public States currentState;
    public GameObject playing = null;
    public GameObject pause;
    public GameObject dead;
    public Canvas pauseCanvas;
    public Canvas deadCanvas;
  
    public Player Player;

    // Start is called before the first frame update
    void Start()
    {

        currentState = States.MENU;
        pauseCanvas.enabled = false;
        deadCanvas.enabled = false;
        
        

    }

    // Update is called once per frame
    void Update()
    {

        
        //GetState();

       
    }

    public void GetState(States states){
        

        switch (currentState) {
            case States.MENU:
                Debug.Log(currentState); 
                Menu();
                break;

            case States.PLAYING:
                Play();
                Debug.Log(currentState);
                break;

            case States.PAUSED:
                Pause();
                Debug.Log(currentState);
                break;
            case States.DEAD:
                Dead();
                Debug.Log(currentState);
                break;

            case States.QUIT:
                Quit();
                Debug.Log(currentState);
                break;
        }
    }


    public void Play() {

        currentState = States.PLAYING;
        playing.SetActive(true);
        pause.SetActive(false);
        dead.SetActive(false);
        
        //SceneManager.LoadScene("2d");
        

        
    }


    public void Menu()
    {
        SceneManager.LoadScene("mainMenu");
        currentState = States.MENU;
        playing.SetActive(false);
        pause.SetActive(false);
        dead.SetActive(false);
        
        

    }


    public void Pause()
    {
        currentState = States.PAUSED;
        pauseCanvas.enabled  = true;
        pause.SetActive(true);
        playing.SetActive(false);
        dead.SetActive(false);
        
    }
    public void Dead()
    {
        currentState = States.DEAD;
        deadCanvas.enabled = true;
        dead.SetActive(true);
        pause.SetActive(false);
        playing.SetActive(false);
        
        
        
    }

    public void LoadPlayState() {
        SceneManager.LoadScene("2d");
    }


    public void Quit()
    {
        currentState = States.QUIT;
        Application.Quit();
    }

}
