using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnRandomlyInASphere : MonoBehaviour
{
    [SerializeField] private InputActionReference mouseClick;
    [SerializeField] private GameObject gameObjectToSpawn;
    [SerializeField] private int spawnCount;
    [SerializeField] private float radius;

    public List<Transform> spawnList = new List<Transform>();
    public bool listUpdated = false;

    private void OnEnable()
    {
        mouseClick.action.performed += ctx => SpawnObjects();
    }

    private void Start()
    {
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        foreach (Transform obj in spawnList)
        {
            Destroy(obj.gameObject);
        }
        spawnList.Clear();

        for (int i = 0; i < spawnCount; i++)
        {
            var spawned = Instantiate(gameObjectToSpawn, this.transform);

            var x = Random.Range(-1f, 1f);
            var y = Random.Range(-1f, 1f);
            var z = Random.Range(-1f, 1f);

            var vec = new Vector3(x, y, z).normalized * Random.Range(0f, radius);
            spawned.transform.position = vec;
            spawnList.Add(spawned.transform);
        }

        listUpdated = true;
    }
}
