using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float speedPerSecond = 1f;
    [SerializeField] private float turnSpeed = 200f;

    private int steerValue;

    // Start is called before the first frame update


    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("box")){
            SceneManager.LoadScene("main");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (speed <= 50){
            speed += speedPerSecond * Time.deltaTime;
            turnSpeed += 0.005f;
        }
        transform.Rotate(0f, steerValue*turnSpeed*Time.deltaTime,0f);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    public void setSteerValue(int num){
        steerValue = num;
    }
}
