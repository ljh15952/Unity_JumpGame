using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

    public Text CoinText;
    // 스타트 부스터 업글 관련
    public GameObject FirstPlatform;
    public Text StartBusterCoinText;
    public static int StartBusterINT = 500;
    public static float StartPlatformJumpForce = 15f;
    //
    // 캐릭터 스피드 업글 관련
    public Text ChartorSpeedText;
    public static int ChartorSpeedINT = 500;
    public static float ChartorSpeed = 2.5f;
    //

    // 코인 갯수관련
    public Text CoinAmountText;
    public static int CoinAmountINT = 500;
    public static int coinAmount = 100;
    //

    private void Start()
    {
      //  PlayerPrefs.DeleteAll();
        //스타트 부스터 업글관련
        StartPlatformJumpForce = PlayerPrefs.GetFloat("jumpforce", StartPlatformJumpForce);
        StartBusterINT = PlayerPrefs.GetInt("startBint", StartBusterINT);

        StartBusterCoinText.text = StartBusterINT.ToString();
        FirstPlatform.GetComponent<GroundScript>().jumpForce = StartPlatformJumpForce;
        //
        //스피드 업글관련
        ChartorSpeed = PlayerPrefs.GetFloat("Speed", ChartorSpeed);
        ChartorSpeedINT = PlayerPrefs.GetInt("Speedint", ChartorSpeedINT);
        BirdScript.Speed = ChartorSpeed;
        ChartorSpeedText.text = ChartorSpeedINT.ToString();
        //
        //코인 갯수관련

        coinAmount = PlayerPrefs.GetInt("coinA", coinAmount);
        CoinAmountINT = PlayerPrefs.GetInt("coinint", CoinAmountINT);

        LevelGenerator.numberOfCoins = CoinAmountINT;
        CoinAmountText.text = CoinAmountINT.ToString();
        //
    }

    public void BuyStartBuster()
    {
        if (BirdScript.coinINT >= StartBusterINT)
        {
            StartPlatformJumpForce += 2;
            PlayerPrefs.SetFloat("jumpforce", StartPlatformJumpForce);

            FirstPlatform.GetComponent<GroundScript>().jumpForce = StartPlatformJumpForce;

            BirdScript.coinINT -= StartBusterINT;
            PlayerPrefs.SetInt("Money", BirdScript.coinINT);

            StartBusterINT += 500;
            PlayerPrefs.SetInt("startBint", StartBusterINT);

            StartBusterCoinText.text = StartBusterINT.ToString();
            RefreshCoin();
        }
    }

    public void BuyChartorSpeed()
    {
        if (BirdScript.coinINT >= ChartorSpeedINT)
        {
            ChartorSpeed += 0.5f;
            PlayerPrefs.SetFloat("Speed", ChartorSpeed);

            BirdScript.Speed = ChartorSpeed;

            BirdScript.coinINT -= ChartorSpeedINT;

            ChartorSpeedINT += 500;
            PlayerPrefs.SetFloat("Speedint", ChartorSpeedINT);
            ChartorSpeedText.text = ChartorSpeedINT.ToString();
            RefreshCoin();
        }
    }

    public void BuyCoinAmount()
    {
        if (BirdScript.coinINT >= CoinAmountINT)
        {
            coinAmount += 30;
            PlayerPrefs.SetInt("coinA", coinAmount);

            LevelGenerator.numberOfCoins += coinAmount;

            LevelGenerator.coinY += 0.3f;
            PlayerPrefs.SetFloat("coinY", LevelGenerator.coinY);

            BirdScript.coinINT -= CoinAmountINT;
            CoinAmountINT += 500;
            PlayerPrefs.SetInt("coinint", CoinAmountINT);

            CoinAmountText.text = CoinAmountINT.ToString();
            RefreshCoin();
        }
    }

    public void RefreshCoin()
    {
        CoinText.text = BirdScript.coinINT.ToString();
        PlayerPrefs.Save();
    }
}
