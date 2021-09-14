using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float speedPerSecond = 1f;
    [SerializeField] private float turnSpeed = 200f;

    [SerializeField] private GameObject gameOverHandler;

    [SerializeField] private GameObject scoreSystemObject;

    private int steerValue;

    // Start is called before the first frame update


    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("box")){
            ScoreSystem s = scoreSystemObject.GetComponent<ScoreSystem>();
            s.EndGame();
            gameObject.SetActive(false);
            gameOverHandler.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (speed <= 49){
            speed += speedPerSecond * Time.deltaTime;
            turnSpeed += 0.002f;
        }
        transform.Rotate(0f, steerValue*turnSpeed*Time.deltaTime,0f);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    public void setSteerValue(int num){
        steerValue = num;
    }
}
