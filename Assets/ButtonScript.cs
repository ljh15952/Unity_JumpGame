using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonScript : MonoBehaviour {

    public GameObject Bird;
    public GameObject ShopButton;
    public Text MoneyText;
    private void Start()
    {
        BirdScript.coinINT = PlayerPrefs.GetInt("Money", BirdScript.coinINT);
        MoneyText.text = BirdScript.coinINT.ToString();
    }

    public void StartButton()
    {
        Bird.GetComponent<BirdScript>().isgamestart = true;
        Bird.GetComponent<BirdScript>().rb.gravityScale = 1;
        ShopButton.SetActive(false);

    }
    public void ReStartButton()
    {
        SceneManager.LoadScene("g");

    }
}
