using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu]
public class SpawnScript : ScriptableObject
{
    public GameObject enemy;
    public int spawnTime;
    public Vector2 spawnPoint;
    public Animator animator;
}

