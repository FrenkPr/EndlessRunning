using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TilesGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private List<GameObject> Tiles;

    private Vector3 newTileOffset;

    // Start is called before the first frame update
    void Start()
    {
        newTileOffset = new Vector3(0, 0, 30);


    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.z >= transform.GetChild(transform.childCount - 9).position.z)
        {
            GameObject tile = Instantiate(Tiles[Random.Range(0, Tiles.Count)], transform);

            tile.transform.localPosition = transform.GetChild(transform.childCount - 2).localPosition + newTileOffset;

            Destroy(transform.GetChild(0).gameObject);
        }
    }
}
