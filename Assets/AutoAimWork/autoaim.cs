using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoaim : MonoBehaviour
{
    public GameObject Projectile;
    public GameObject Thrower;

    private Vector3 LaunchPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            Spawn();
        }
    }
    void Spawn()
    {
        LaunchPosition = Thrower.transform.position;
        Instantiate(Projectile,LaunchPosition, Quaternion.identity);
    }
}
