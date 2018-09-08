using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour {

    public GameObject ReBt;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("bird"))
        {
            if(collision.transform.position.y>BirdScript.highScore)
            {
                BirdScript.highScore = collision.transform.position.y;
            }
            ReBt.SetActive(true);
            PlayerPrefs.SetInt("Money", BirdScript.coinINT);
            PlayerPrefs.Save();
            collision.gameObject.SetActive(false);
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
