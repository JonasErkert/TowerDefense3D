using UnityEngine;

[System.Serializable]
public class Wave {

    public GameObject enemyPrefab;  // Der Gegner- Typ
    public int enemyCount;          // Anzahl der zu spawnenden Gegner
    public float rate;              // Gegner pro Sekunde

}
