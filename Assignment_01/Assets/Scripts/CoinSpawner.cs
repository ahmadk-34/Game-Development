using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject[] coinPrefabs;

    public int coinsPerBatch = 5;

    public float minX = -8f;
    public float maxX = 8f;
    public float minY = -4f;
    public float maxY = 4f;

    private int remainingCoins;

    void Start()
    {
        SpawnCoins();
    }

    void SpawnCoins()
    {
        remainingCoins = coinsPerBatch;

        for (int i = 0; i < coinsPerBatch; i++)
        {
            int randomType = Random.Range(0, coinPrefabs.Length);

            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            Vector3 position = new Vector3(randomX, randomY, 0);

            Instantiate(
                coinPrefabs[randomType],
                position,
                Quaternion.identity
            );
        }
    }

    public void CoinCollected()
    {
        remainingCoins--;

        if (remainingCoins == 0)
        {
            SpawnCoins();
        }
    }
}