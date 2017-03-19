using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class Wave : ScriptableObject {


    public List<SpawnScript> spawnList;

    public float waveTime;

    void AddNew()
    {
        spawnList.Add(new SpawnScript());

    }

    private void Remove(int index)
    {
        spawnList.RemoveAt(index);
    }
}
