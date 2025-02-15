using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InternalTimer
{
    public float cooldown;
    private float time;
    public InternalTimer(float cooldown)
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
    InternalTimer patientTimer;
    public List<GameObject> allPatients = new List<GameObject>();
    float maxSpawnRange = 0;
    public Player player;
    public Image directionArrow;

    void Start()
    {
        patientTimer = new InternalTimer(10);
        maxSpawnRange = GetComponent<RoadGeneration>().streetLength;
    }

    // Update is called once per frame
    void Update()
    {
        ParentDirectionArrow();
        FirstPatientDirection();

        if (patientTimer.Update())
        {
            RoadGeneration roadGen = GetComponent<RoadGeneration>();
            Vector3 spawnPosition = new Vector3(0, 0, 0);

            allPatients.Add(Instantiate(patientPrefab));
            GameObject newestPatient = allPatients[allPatients.Count - 1];
            newestPatient.GetComponent<Patient>().manager = this;
            do
            {
                spawnPosition = new Vector3(Random.Range(0, maxSpawnRange), Random.Range(0, maxSpawnRange), 0);
            }
            while (roadGen.roadMap.GetTile(new Vector3Int((int)spawnPosition.x, (int)spawnPosition.y)) != (roadGen.roadTile | roadGen.sidewalkTile));
            newestPatient.transform.position = spawnPosition;
            newestPatient.GetComponent<Patient>().manager = this;
        }
    }

    private void ParentDirectionArrow()
    {
        if (allPatients.Count < 1) directionArrow.transform.localScale = Vector3.zero;
        else directionArrow.transform.localScale = Vector3.one;
    }

    private void FirstPatientDirection()
    {
        if (allPatients.Count < 1 || player.parked) return;
        Vector3 target = new Vector3(0, 0);
        if (player.carrying)
        {
            target = new Vector3(16, 18);
            directionArrow.color = new Color(1, 0.1f, 0.1f);
        }
        else
        {
            target = allPatients[0].transform.position;
            directionArrow.color = Color.white;
        }

        Vector3 playerPosition;

        if (player.ambulance.entered) playerPosition = player.ambulance.transform.position;
        else playerPosition = player.transform.position;

        float angle = Mathf.Atan2(target.y - playerPosition.y, target.x - playerPosition.x) * Mathf.Rad2Deg;
        directionArrow.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
