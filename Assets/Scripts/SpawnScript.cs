using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu]
public class SpawnScript : ScriptableObject
{
    public GameObject enemy;
    public float speed;
    public float spawnTime;
    public Vector2 spawnPoint;
    public List<Vector2> waypoints;

}

