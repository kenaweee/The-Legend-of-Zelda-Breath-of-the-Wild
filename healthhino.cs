using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class healthhino : MonoBehaviour
{
    public int health = 150;
    public Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(4);
        }

        if(health <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void TakeDamage(int damage)
    {
        health = health - damage;
        healthBar.value = health;
        Debug.Log(health);
        
    }
}
