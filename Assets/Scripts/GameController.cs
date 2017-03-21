using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public float startWait;

    private List<Wave> wavelist;



    void Start()
    {
        wavelist = GetComponent<WaveList>().waveList;
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
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
        List<Vector2> flightpath = new List<Vector2>();
        int i = 0;
        foreach (Vector2 vec in spawn.waypoints)
        {
            flightpath.Add(spawn.waypoints[i]);
            if (i - 1 >= 0 && spawn.waitAtPoint.Length != 0 && spawn.secsToWait.Length == spawn.waitAtPoint.Length && spawn.secsToWait[i-1] != 0)
            {
                yield return new WaitForSeconds(spawn.secsToWait[i-1]);
            }
            while (obj && Vector2.Distance(obj.transform.position, vec) > .10f)
            {
                
                if (obj)
                {
                    Vector2 start = obj.transform.position;
                    if (start.Equals(vec))
                        break;
                    obj.transform.position = Vector2.MoveTowards(obj.transform.position, vec, Time.deltaTime * spawn.speed);
                    yield return null;
                }
            };
            i++;
        }
    }
}
       



