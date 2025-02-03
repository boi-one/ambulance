using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    public float cooldown;
    private float time;
    public Timer(float cooldown)
    {
        this.cooldown = cooldown;
    }

    public bool Update()
    {
        if (Time.time > time)
        {
            time = Time.time + cooldown;
            return true;
        }
        return false;
    }
}

public class PatientManager : MonoBehaviour
{
    public GameObject patientPrefab;
    Timer patientTimer;
    public List<GameObject> allPatients = new List<GameObject>();
    float maxSpawnRange = 0;
    // Start is called before the first frame update
    void Start()
    {
        patientTimer = new Timer(10);
        maxSpawnRange = GetComponent<RoadGeneration>().streetLength;
    }

    // Update is called once per frame
    void Update()
    {
        if (patientTimer.Update())
        {
            RoadGeneration roadGen = GetComponent<RoadGeneration>();
            Vector3 spawnPosition = new Vector3(0, 0, 0);

            allPatients.Add(Instantiate(patientPrefab));
            GameObject newestPatient = allPatients[allPatients.Count - 1];
            do
            {
                spawnPosition = new Vector3(Random.Range(0, maxSpawnRange), Random.Range(0, maxSpawnRange), 0);
            }
            while(roadGen.roadMap.GetTile(new Vector3Int((int)spawnPosition.x, (int)spawnPosition.y)) != (roadGen.roadTile | roadGen.sidewalkTile));
            Debug.Log(spawnPosition);
            newestPatient.transform.position = spawnPosition;
        }
    }
}
