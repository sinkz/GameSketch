using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour {

    public float speed;
    private float x;
    public GameObject Player;
    private bool score;


	void Start () {
        Player = GameObject.Find("Player") as GameObject;
	}
	
	
	void Update () {
        x = transform.position.x;
        x += speed * Time.deltaTime;

        transform.position = new Vector3(x, transform.position.y, transform.position.z);
	
        if(x <= -7)
        {
            Destroy(transform.gameObject);
        }

        if(x < Player.transform.position.x && !score)
        {
            score = true;
            PlayerController.score++;
        }
	}
}
