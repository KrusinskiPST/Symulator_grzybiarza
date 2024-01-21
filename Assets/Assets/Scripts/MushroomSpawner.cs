using UnityEngine;
using UnityEngine.UI;

public class MushroomSpawner : MonoBehaviour
{
    public GameObject[] mushroomPrefabs;
    public int numberOfMushrooms = 10;
    public Vector3 areaSize = new Vector3(10, 0, 10);
    public float maxHeight = 100.0f;

    public Text pickupText; // Referencja do tekstu UI
    public float fadeSpeed = 1f; // Prêdkoœæ efektu fade

    private float targetAlpha = 0; // Docelowa przezroczystoœæ tekstu

    void Start()
    {
        SpawnMushrooms();
        pickupText.color = new Color(pickupText.color.r, pickupText.color.g, pickupText.color.b, 0); // Ustaw pocz¹tkow¹ przezroczystoœæ na 0
    }

    void Update()
    {
        RaycastHit hit;
        bool hitMushroom = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f) && hit.collider.gameObject.CompareTag("Mushroom");

        // Ustaw docelow¹ przezroczystoœæ
        targetAlpha = hitMushroom ? 1.0f : 0.0f;

        // Aktualizuj przezroczystoœæ tekstu
        Color currentColor = pickupText.color;
        currentColor.a = Mathf.Lerp(currentColor.a, targetAlpha, fadeSpeed * Time.deltaTime);
        pickupText.color = currentColor;

        // Interakcja z grzybem
        if (hitMushroom && Input.GetKeyDown(KeyCode.E))
        {
            PickupMushroom(hit.collider.gameObject);
        }
    }

    void SpawnMushrooms()
    {
        for (int i = 0; i < numberOfMushrooms; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-areaSize.x / 2, areaSize.x / 2),
                maxHeight,
                Random.Range(-areaSize.z / 2, areaSize.z / 2)
            ) + transform.position;

            RaycastHit hit;
            if (Physics.Raycast(randomPosition, Vector3.down, out hit))
            {
                // Sprawdzanie, czy promieñ trafi³ w powierzchniê
                Vector3 spawnPosition = hit.point;
                GameObject mushroomPrefab = mushroomPrefabs[Random.Range(0, mushroomPrefabs.Length)];
                Instantiate(mushroomPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }

    void PickupMushroom(GameObject mushroom)
    {
        // Logika zbierania grzyba
        Destroy(mushroom);
    }
}
