using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public GameObject platformPrefab;
    public GameObject CoinPrefab;
    public int numberOfPlatforms;
    public static int numberOfCoins =100;
    public float Levelwidth = 3f;
    public float minY = .2f;
    public float maxY = 1.5f;

    public static float coinY = 0.5f;

	void Start () {
        coinY = PlayerPrefs.GetFloat("coinY", coinY);

        Vector3 spawnPosition = new Vector3();
        Vector3 coinspawnPosition = new Vector3();
        for (int i=0;i<numberOfPlatforms;i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-Levelwidth, Levelwidth);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }
        for (int i = 0; i < numberOfCoins; i++)
        {
            coinspawnPosition.y += Random.Range(minY-coinY, maxY+2);
            coinspawnPosition.x = Random.Range(-Levelwidth, Levelwidth);
            Instantiate(CoinPrefab, coinspawnPosition, Quaternion.identity);
        }
    }
	
	void Update () {
		
	}
}
