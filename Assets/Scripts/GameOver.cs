using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    public Text score;
    public Text highScore;

	// Use this for initialization
	void Start () {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore.text = PlayerPrefs.GetInt("highScore").ToString();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
