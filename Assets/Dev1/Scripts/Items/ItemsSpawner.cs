using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ItemsSpawner : MonoBehaviour
{
    [SerializeField] private List<DataItemSO> _listDataItemsSO;

    [SerializeField] private List<Item> _listItemPrefab;
    [SerializeField] private List<Transform> _listItemSpawnPoints;

    private void Start()
    {
        SpawnItems();
    }

    private async void SpawnItems()
    {
        foreach (Transform point in _listItemSpawnPoints)
        {
            //Item item = Instantiate(_itemPrefab, point.position, Quaternion.identity);
            //item.Initialize(_listDataItemsSO);
            await Task.Yield();

            Item item1 = Instantiate(_listItemPrefab[0], _listItemSpawnPoints[0].position, Quaternion.identity);
            Item item2 = Instantiate(_listItemPrefab[1], _listItemSpawnPoints[1].position, Quaternion.identity);
        }
    }
}
