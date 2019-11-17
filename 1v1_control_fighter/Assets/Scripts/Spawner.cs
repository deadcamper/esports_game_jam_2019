using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject spawnTemplate;

    public bool spawnFirstImmediately;

    public float minimumSpawnDelay;
    public float maximumSpawnDelay;

    public bool waitUntilLastSpawnedObjectIsDestroyed;

    private float countDown;
    private GameObject lastSpawnedObject;

    void Start()
    {
        if (spawnTemplate == null)
        {
            Debug.LogWarning("Template object for spawner was not defined or was destroyed.");
        }

        if (spawnTemplate.scene.name != null)
        {
            spawnTemplate.gameObject.SetActive(false); // Hide!!!
        }

        if (spawnFirstImmediately)
        {
            Spawn();
        }
        else
        {
            InitializeSpawnCountDown();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CanSpawn())
        {
            countDown -= Time.deltaTime * Time.timeScale;
            if (countDown <= 0)
            {
                Spawn();
            }
        }
    }

    private void InitializeSpawnCountDown()
    {
        countDown = Random.Range(minimumSpawnDelay, maximumSpawnDelay);
    }

    public void Spawn()
    {
        if (spawnTemplate == null)
        {
            Debug.LogWarning("Failed to spawn an object. No template defined.");
        }
        else
        {
            lastSpawnedObject = Instantiate(spawnTemplate, transform.position, spawnTemplate.transform.rotation, null);
            lastSpawnedObject.gameObject.SetActive(true);
        }
        InitializeSpawnCountDown();
    }

    private bool CanSpawn()
    {
        return (!waitUntilLastSpawnedObjectIsDestroyed || !lastSpawnedObject);
    }

    private void OnDestroy()
    {
        lastSpawnedObject = null;
    }
}
