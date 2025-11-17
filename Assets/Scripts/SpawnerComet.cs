using UnityEngine;

public class CometSpawner : MonoBehaviour
{
    public GameObject cometPrefab;

    [Header("Częstotliwość spawnów (trudność)")]
    public float startSpawnInterval = 1.2f;     // początkowy odstęp między kometami
    public float minSpawnInterval = 0.3f;       // minimalny odstęp (max trudność)
    public float difficultyIncreaseRate = 0.01f; // jak szybko rośnie trudność

    [Header("Pozycja spawnu")]
    public float xRange = 8f;   // zakres losowego X

    [Header("Kierunek lotu")]
    public float spreadAngle = 45f;     // rozrzut kątów komet

    [Header("Prędkość komet")]
    public float baseSpeed = 5f;            // bazowa prędkość
    public float speedRandomness = 2f;      // +/- losowa prędkość

    private float timer = 0f;
    private float elapsedTime = 0f;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        timer += Time.deltaTime;

        // im dłużej gramy, tym częściej lecą komety
        float currentInterval = Mathf.Max(
            minSpawnInterval,
            startSpawnInterval - difficultyIncreaseRate * elapsedTime
        );

        if (timer >= currentInterval)
        {
            SpawnComet();
            timer = 0f;
        }
    }

    void SpawnComet()
    {
        // losowa pozycja X na górze
        float randomX = Random.Range(-xRange, xRange);
        Vector3 spawnPos = new Vector3(randomX, transform.position.y, 0f);

        // tworzymy kometę
        GameObject cometObj = Instantiate(cometPrefab, spawnPos, Quaternion.identity);

        // pobieramy skrypt Comet
        Comet cometScript = cometObj.GetComponent<Comet>();

        if (cometScript != null)
        {
            // LOSOWY KĄT
            // spreadAngle = max odchylenie w lewo/prawo
            float angle = Random.Range(-spreadAngle, spreadAngle);

            // obracamy wektor Vector2.down o ten kąt
            Vector2 dir = Quaternion.Euler(0f, 0f, angle) * Vector2.down;
            cometScript.moveDirection = dir.normalized;

            // LOSOWA PRĘDKOŚĆ
            float speedOffset = Random.Range(-speedRandomness, speedRandomness);
            cometScript.speed = Mathf.Max(1f, baseSpeed + speedOffset);
        }
    }
}
