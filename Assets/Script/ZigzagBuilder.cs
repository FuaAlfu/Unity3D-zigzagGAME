using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.7.27
/// </summary>

public class ZigzagBuilder : MonoBehaviour
{
    [Header("MAIN")]
    [Tooltip("tile")]
    [SerializeField]
    private GameObject tilePrefabe;

    [SerializeField]
    private GameObject player;
    //--------------------------

    private List<GameObject> Tiles;
    private Vector3 nextDirection = Vector3.right;

    // Start is called before the first frame update
    void Start()
    {
        Tiles = new List<GameObject>() { Instantiate(tilePrefabe, new Vector3(3, 0, 2), Quaternion.identity) }; //calc by size of base
        for(int i = 0; i < 29; i++) //add 29, we could add less or more
        {
            AddNewTile();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, Tiles[(Tiles.Count - 1) / 2].transform.position) < 2)
        {
            AddNewTile();
        }
    }

    private void AddNewTile()
    {
        Color newColor = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
        nextDirection = (UnityEngine.Random.Range(0, 2) == 1 ? Vector3.right : Vector3.forward);
        if(Tiles.Count < 30)
        {
            Tiles.Add(Instantiate(tilePrefabe, Tiles[Tiles.Count - 1].transform.position + nextDirection, Quaternion.identity));
            Tiles[Tiles.Count - 1].GetComponent<MeshRenderer>().material.color = newColor;
        }
        else
        {
            Tiles[0].transform.position = Tiles[Tiles.Count - 1].transform.position + nextDirection;
            Tiles[0].GetComponent<MeshRenderer>().material.color = newColor;
            Tiles.Add(Tiles[0]);
            Tiles.RemoveAt(0);
        }
    }
}
