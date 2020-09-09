using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Transform aroundObj;
    public float rotSpeed=0.1f;

    public bool MoveBack = false;

    public float moveBackSpeed = 0.02f;

    void Update()
    {
        //transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
        Debug.DrawLine(transform.position, aroundObj.position, Color.red);
        
        if(aroundObj != null)
        {
            transform.RotateAround(aroundObj.position, new Vector3(0, 0, 10), rotSpeed);
        }
            

        if(GameManager.Instance.isDragging != true && MoveBack == true)
        {
            var napr = aroundObj.position - transform.position;
            transform.position += napr * moveBackSpeed;
        }
    }

    //------------------------------------------------------
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "GravTrig")
        {
            aroundObj = other.gameObject.transform;
            MoveBack = false;
        }

        if(other.gameObject.tag == "die")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "GravTrig"){
            MoveBack = true;
        }
    }
    public void MoveForv(){
        var napr = transform.position - aroundObj.position;
        transform.position += napr * 0.02f;
        //transform.position = new Vector2( transform.position.x, transform.position.y + 0.01f);
    }
}
