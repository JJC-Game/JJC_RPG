using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemSelector : MonoBehaviour
{
    JobWorld jobworld;
    GameObject bearPrefab;
    GameObject bearInstance;

    // Start is called before the first frame update
    void Start()
    {
        jobworld = GameObject.Find("JobWorld").GetComponent<JobWorld>();
        int bearId = Random.Range(0, jobworld.bearList.Count);
        bearPrefab = jobworld.bearList[bearId];
        bearInstance = Instantiate(bearPrefab);
        bearInstance.transform.SetParent(this.transform);
        bearInstance.transform.localPosition = Vector3.zero;
        bearInstance.transform.localRotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
