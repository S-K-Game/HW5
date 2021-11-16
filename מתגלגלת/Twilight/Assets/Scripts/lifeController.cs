using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class lifeController : MonoBehaviour
{
    public GameObject heart1, heart2, heart3, player;
    public static int life;

    // Start is called before the first frame update
    void Start()
    {
        life =3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(life > 3){life = 3;}
        switch(life){
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;
            
            case 2:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;

            case 1:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(true);
                break;

            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                Destroy(player.gameObject);
                break;
        }   
    }
}