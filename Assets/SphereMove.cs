using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class SphereMove : MonoBehaviour
{

    public int score = 0;
    public TMP_Text scoreText;
    public GameObject pauseText;
    private bool countdown;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        countdown = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 10 * Time.deltaTime;

        //if (Input.GetKey(KeyCode.UpArrow))
        //    transform.position += new Vector3(0, 0, speed);
        //if (Input.GetKey(KeyCode.DownArrow))
        //    transform.position -= new Vector3(0, 0, speed);
        //if (Input.GetKey(KeyCode.RightArrow))
        //    transform.position += new Vector3(speed, 0, 0);
        //if (Input.GetKey(KeyCode.LeftArrow))
        //    transform.position -= new Vector3(speed, 0, 0);

        float horizMove = Input.GetAxisRaw("Horizontal") * speed;
        float vertMove = Input.GetAxisRaw("Vertical") * speed;
        transform.position += new Vector3(horizMove, 0, vertMove);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.timeScale == 0 )
            {
                //unpausing
                pauseText.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                //pausing
                pauseText.SetActive(true);
                Time.timeScale = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            countdown = true;
        }

        if (countdown)
        {
            //timer stuff
            if(timer < 3)
            {
                timer += Time.deltaTime;
                Debug.Log(timer);
            }
            else
            {
                //Application.Quit();
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other){
        float newX = Random.Range(-12, 12);
        float newZ = Random.Range(-5, 5);
        other.transform.position = new Vector3(newX, 0, newZ);

        score++;
        scoreText.text = "Score: " + score;
    }





}
