using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D playerRigidbody;
    public int forceJump;
    public Animator Anime;
    private bool dash;

    //Verify ground
    public Transform GroundCheck;
    public bool isGrounded;
    public LayerMask whatIsGround;

    //Verify Dash
    public float timeTemp;
    public float dashTemp;

    //Colisor
    public Transform colisor;

    //Audio
    public AudioSource audio;
    public AudioClip soundJump;
    public AudioClip soundDash;

    //Score
    public Text txtScore;
    public static int score;


	// Use this for initialization
	void Start () {
        score = 0;
        PlayerPrefs.SetInt("score", score);
    }
	
	// Update is called once per frame
	void Update () {

        txtScore.text = score.ToString();

        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            playerRigidbody.AddForce(new Vector2(0, forceJump));
            audio.PlayOneShot(soundJump);
            audio.volume = 1;
            if (dash)
            {
                colisor.position = new Vector3(colisor.position.x, colisor.position.y + 0.3f);
                dash = false;
            }
            
        }

        if (Input.GetMouseButtonDown(1) && isGrounded && !dash)
        {
            audio.PlayOneShot(soundDash);
            audio.volume = 0.5f;
            colisor.position = new Vector3(colisor.position.x, colisor.position.y - 0.3f);
            dash = true;
            timeTemp = 0;
        }

        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, whatIsGround);

        //Controll dash time
        if (dash)
        {
            timeTemp += Time.deltaTime;
            if(timeTemp >= dashTemp)
            {
                colisor.position = new Vector3(colisor.position.x, colisor.position.y + 0.3f);
                dash = false;
            }
        }


        Anime.SetBool("Jump", !isGrounded);
        Anime.SetBool("Dash", dash);
	
	}

    void OnTriggerEnter2D()
    {
        PlayerPrefs.SetInt("score", score);
        if(score > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", score);
        }
        SceneManager.LoadScene("GameOver");
    }
}
