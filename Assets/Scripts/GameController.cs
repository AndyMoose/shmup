using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public float startWait;

    private List<Wave> wavelist;

	void Start () {
        wavelist = GetComponent<WaveList>().waveList;
        StartCoroutine(SpawnWaves());
	}
	
    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds(startWait);
        foreach (Wave wave in wavelist)
        {
            float waveWait = wave.waveTime;
            StartCoroutine(SpawnThroughWave(wave));
            yield return new WaitForSeconds(waveWait);
        }    
        
    }

    IEnumerator SpawnThroughWave(Wave wave)
    {
        
        List<SpawnScript> spawnlist = wave.spawnList;
        foreach (SpawnScript spawn in spawnlist)
        {
            yield return new WaitForSeconds(spawn.spawnTime);
            Instantiate(spawn.enemy, spawn.spawnPoint, Quaternion.identity);
            SpawnMove(spawn);
        }
    }

    void SpawnMove(SpawnScript spawn)
    {
        //???
    {

    }
}

}
