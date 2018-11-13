using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{

    //public AudioClip audioClip;
    //public Text text;
    //public ParticleSystem particle;

    //private AudioSource audioSource;
    Vector3 rotatePoint = Vector3.zero;
    Vector3 rotateAxis = Vector3.zero;
    float cubeAngle = 0f;

    float cubeSizeHalf;
    bool isRotate = false;

    void Start()
    {
        cubeSizeHalf = transform.localScale.x / 2f;
        //audioSource = gameObject.GetComponent<AudioSource>();
        //audioSource.clip = audioClip;
    }

    void Update()
    {
        //text.text = "Score: " + OnCollision.score;
        if (isRotate)
            return;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rotatePoint = transform.position + new Vector3(cubeSizeHalf, -cubeSizeHalf, 0f);
            rotateAxis = new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotatePoint = transform.position + new Vector3(-cubeSizeHalf, -cubeSizeHalf, 0f);
            rotateAxis = new Vector3(0, 0, 1);
        }

        if (rotatePoint == Vector3.zero)
            return;
        StartCoroutine(MoveCube());
    }

    IEnumerator MoveCube()
    {
        //audioSource.Play();
        isRotate = true;

        float sumAngle = 0f;
        while (sumAngle < 90f)
        {
            cubeAngle = 15f;
            sumAngle += cubeAngle;

            if (sumAngle > 90f)
            {
                cubeAngle -= sumAngle - 90f;
            }
            transform.RotateAround(rotatePoint, rotateAxis, cubeAngle);
            //Instantiate(particle, transform.position, transform.rotation);
            //particle.Emit(1);

            yield return null;
        }

        isRotate = false;
        rotatePoint = Vector3.zero;
        rotateAxis = Vector3.zero;

        yield break;
    }

}


