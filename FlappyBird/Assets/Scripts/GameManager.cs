using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour 
{
    public static GameManager Instance;        
    [SerializeField] private TMP_Text ScoreText;                       
    [SerializeField] private GameObject GameOverText;
    [SerializeField] private GameObject ReadyText;                 
    public bool GameOver = false;

    public float scrollSpeed {get; private set;} 

    private int score = 0;
    private bool ready = false;                     
                  
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if(Instance != this)
            Destroy (gameObject);

        scrollSpeed = -1.5f;
    }

    private void Update()
    {
        if(!ready)
        {
            ReadyText.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            ReadyText.SetActive(false);
            Time.timeScale = 1;
        }
        
        if (GameOver && Input.GetButtonDown("Fire1")) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if(!ready && Input.GetButtonDown("Fire1"))
        {
            ready = true;
        }
    }

    public void BirdScored()
    {
        if (GameOver)    
            return;

        score++;
        ScoreText.text = "Score: " + score.ToString();
    }

    public void BirdDied()
    {
        GameOverText.SetActive (true);
        GameOver = true;
    }
}