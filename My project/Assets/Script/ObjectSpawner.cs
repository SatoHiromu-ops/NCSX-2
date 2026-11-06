
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("生成するオブジェクト")]
    [SerializeField] private GameObject[] objectPrefabs;

    [Header("生成間隔")]
    [SerializeField] private float minSpawnTime = 1f;
    [SerializeField] private float maxSpawnTime = 3f;

    [Header("生成位置")]
    [SerializeField] private float spawnOffset = 2f;
    [SerializeField] private float minY = -3f;
    [SerializeField] private float maxY = 3f;

    private Camera mainCamera;
    private float timer;

    void Start()
    {
        mainCamera = Camera.main;
        SetNextSpawnTime();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnObject();
            SetNextSpawnTime();
        }
    }


    void SpawnObject()
    {
        if (mainCamera == null ||
            objectPrefabs.Length == 0) return;

        // カメラ右端の座標
        float cameraRight =
            mainCamera.transform.position.x
            + mainCamera.orthographicSize
            * mainCamera.aspect;

        float spawnX = cameraRight + spawnOffset;

        // カメラの上下の表示範囲
        float cameraTop =
            mainCamera.transform.position.y
            + mainCamera.orthographicSize;

        float cameraBottom =
            mainCamera.transform.position.y
            - mainCamera.orthographicSize;

        // 上下の端から少し余裕を持たせる
        float margin = 0.5f;

        // 画面の上下全体からランダム生成
        float spawnY = Random.Range(
            cameraBottom + margin,
            cameraTop - margin
        );

        Vector3 spawnPosition =
            new Vector3(spawnX, spawnY, 0f);

        int index = Random.Range(
            0, objectPrefabs.Length
        );

        Instantiate(
            objectPrefabs[index],
            spawnPosition,
            Quaternion.identity
        );
    }


    void SetNextSpawnTime()
    {
        timer = Random.Range(
            minSpawnTime,
            maxSpawnTime
        );
    }
}
