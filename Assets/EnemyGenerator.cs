using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

    public GameObject enemy;

    int dropRate = 70;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.frameCount % dropRate == 0)
        {
            if (dropRate > 10)
            {
                dropRate--;
            }

            Instantiate(enemy, new Vector3(Random.Range(-9, 9), transform.position.y, transform.position.z), transform.rotation, transform);

        }
	}
}
