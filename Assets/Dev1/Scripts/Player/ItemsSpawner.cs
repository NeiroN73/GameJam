using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ItemsSpawner : MonoBehaviour
{
    [SerializeField] private List<DataItem> _listDataItemsSO;

    [SerializeField] private Item _itemPrefab;
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

            Item item1 = Instantiate(_itemPrefab, _listItemSpawnPoints[0].position, Quaternion.identity);
            item1.Initialize(_listDataItemsSO[0]);
            Item item2 = Instantiate(_itemPrefab, _listItemSpawnPoints[1].position, Quaternion.identity);
            item2.Initialize(_listDataItemsSO[1]);
        }
    }
}
