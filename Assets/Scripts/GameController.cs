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
            GameObject obj = Instantiate(spawn.enemy, spawn.spawnPoint, Quaternion.identity);
            StartCoroutine(SpawnMove(spawn, obj));
        }
    }

    IEnumerator SpawnMove(SpawnScript spawn, GameObject obj)
    {
        Vector2[] flightpath = new Vector2[spawn.waypoints.Count];
        int i = 0;
        foreach (Vector2 vec in spawn.waypoints)
        {
            flightpath[i] = spawn.waypoints[i];
            i++;
        }
        foreach (Vector2 next in flightpath)
        {
                while (obj && Vector2.Distance(obj.transform.position, next) > .10f)
                {
                    if (obj)
                    {
                        Vector2 start = obj.transform.position;
                        if (start.Equals(next))
                            break;
                        obj.transform.position = Vector2.MoveTowards(obj.transform.position, next, Time.deltaTime * spawn.speed);
                        yield return null;
                    }
                };
            }
        }
}


