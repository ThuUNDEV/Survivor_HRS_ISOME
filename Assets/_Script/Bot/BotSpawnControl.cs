using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BotSpawnControl : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _spawnTransformList = new List<Transform>();

    [SerializeField]
    private SlimeControl _slimeControl = null;

    [SerializeField]
    private float _timeSpawnBot = 5f;

    [SerializeField]
    private int _maximumBotSpawn = 3;

    [SerializeField]
    private Transform _playerTransform = null;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnBot), 1, _timeSpawnBot);
    }

    private void SpawnBot()
    {
        GameObject slimeObject = ObjectPool.Instance(_slimeControl.gameObject);

        if (_spawnTransformList.Count > 0)
        {
            int randomIndex = Random.Range(0, _spawnTransformList.Count);

            Transform spawnTrasn = _spawnTransformList[randomIndex];

            slimeObject.transform.position = spawnTrasn.position;

            if (_playerTransform != null)
            {
                slimeObject.GetComponent<SlimeControl>().SetTargetTransform(_playerTransform);
            }
        }
    }
}
