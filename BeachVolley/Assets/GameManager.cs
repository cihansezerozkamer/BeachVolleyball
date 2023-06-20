using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource musicSource;
    public int score1=0;
    public int score2=0;
    public static GameManager instance;
    public TextMeshProUGUI score1Text;
    public TextMeshProUGUI score2Text;
    public CameraController camera1;
    public CameraController camera2;
    public Transform target1;
    public Transform target2;// The object to rotate around
    public float rotationSpeed = 5f; // The speed of rotation
    public Animator player1;
    public Animator player2;
    public GameObject win1;
    public GameObject win2;
    public GameObject Player1;
    public GameObject Player2;
    public bool isScored=false;
    public Animator audienceAnimator; // Reference to the audience animator

    // Other variables and functions of the game manager

    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        volumeSlider.value = musicSource.volume;

        // Subscribe to the OnValueChanged event of the volume slider
        volumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);
    }
    private void OnVolumeSliderChanged(float volume)
    {
        // Update the volume of the music source
        musicSource.volume = volume;
    }
    private void Update()
    {
        float rotationAmount = rotationSpeed * Time.deltaTime;
      
            
        score1Text.text = score1.ToString();
        score2Text.text = score2.ToString();
        if(score1 == 15)
        {
            score1 = 0;
            camera1.offset = camera1.win;
            camera1.isWon = true;
            camera1.transform.position =camera1.smoothedPosition;
            camera2.transform.position = camera2.smoothedPosition;
            camera2.isWon = true;
            camera2.offset = camera2.win;
            player1.Play("bellydance");
            player2.Play("LOse");
            win1.SetActive(true);
        }
        if (score2 == 15)
        {
            camera2.transform.position = camera2.smoothedPosition;
            camera2.isWon = true;
            camera2.offset = camera2.win;
            camera1.offset = camera1.win;
            camera1.isWon = true;
            camera1.transform.position = camera1.smoothedPosition;
            score2 = 0;
            player2.Play("bellydance");
            player1.Play("LOse");
            win2.SetActive(true);
        }
    }
    public void Restart()
    {
        score1 = 0;
        score2 = 0;
        isScored = true;
        Player1.transform.localPosition= new Vector3(-15, -3.5f, 0);
        Player2.transform.localPosition = new Vector3(5, -3.5f, 0);
    }
}
