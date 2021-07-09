using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPlataformScript : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> plataforms = new List<GameObject>();
    public List<Transform> currentPlataforms = new List<Transform>();

    public int offset = 0;

    private Transform player;
    private Transform currentPlataformPoint;
    private int plataformIndex = 0;
    void Start()
    {
        //player = GameObject.FindGameObjectsWithTag("Player").transform;
        player = GameObject.Find("player").transform;

        for (int i = 0; i < plataforms.Count; i++) 
        {
           Transform p = Instantiate(plataforms[i], new Vector3(0.0f, 0.0f, i * 25), transform.rotation).transform;
            currentPlataforms.Add(p); 
            offset += 25;
        }

        currentPlataformPoint = currentPlataforms[plataformIndex].GetComponent<plataformScript>().point;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = player.position.z - currentPlataformPoint.position.z;

        if(distance >= 5)
        {
            Recycle(currentPlataforms[plataformIndex].gameObject);
            plataformIndex++;

            if (plataformIndex > currentPlataforms.Count -1) {
                plataformIndex = 0;
            }

            currentPlataformPoint = currentPlataforms[plataformIndex].GetComponent<plataformScript>().point;
        }
    }

    public void Recycle(GameObject plataform)
    {
        plataform.transform.position = new Vector3(0, 0, offset);
        offset += 25;
    }
}
