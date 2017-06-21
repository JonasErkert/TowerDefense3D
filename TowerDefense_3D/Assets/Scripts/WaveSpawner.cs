using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public static int EnemiesAlive = 0;

    public Wave[] waves;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public Text waveCountdownText;
    private int waveIndex = 0;

    public GameManager gameManager;

    void Start()
    {
        Debug.Log("WaveSpawner.cs loaded.");
        EnemiesAlive = 0;
    }

    void Update()
    {
        // Wenn eine Welle gespawned wurde countdown anhalten
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            if (PlayerStats.Lives <= 0)
                return;

            if (PlayerStats.Lives > 0)
                gameManager.WinLevel();

            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity); // Damit der counter nicht aus irgendeinem Grund kleiner als 0 wird

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    // Coroutine
    IEnumerator SpawnWave()
    {
        Debug.Log("Spawning new wave!");

        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.enemyCount;

        for (int i = 0; i < wave.enemyCount; i++)
        {
            SpawnEnemy(wave.enemyPrefab);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;     
    }
    
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

}
