using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

    public GameObject wallPrefab;
    public float rateSpawn; //interval spawning objects
    private float currentTime;
    private int position;
    private float y;
    public float posA;
    public float posB;


    // Use this for initialization
    void Start () {
        currentTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        if(currentTime >= rateSpawn)
        {
            currentTime = 0;
            position = Random.Range(1, 100);
            if(position > 50)
            {
                y = posA;
            }
            else
            {
                y = posB;
            }
            GameObject tempPrefab = Instantiate(wallPrefab) as GameObject;
            tempPrefab.transform.position = new Vector3(transform.position.x, y, tempPrefab.transform.position.z);
        }
	}
}
