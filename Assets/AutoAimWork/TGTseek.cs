using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TGTseek : MonoBehaviour
{
    public GameObject MSSL;
    public float MSSLspeed = 1f;
    public Rigidbody2D rb2d;

    Vector3 MSSLhead;
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        RotateMSSL();
        PropelMSSL();
        MSSLonTGTbail();
    }
    void RotateMSSL()
    {
        transform.right = GameObject.FindGameObjectWithTag("TGT").transform.position - MSSL.transform.position;
    }
    void PropelMSSL()
    {
        MSSLhead = GameObject.FindGameObjectWithTag("TGT").transform.position - MSSL.transform.position;
        rb2d.AddForce(MSSLhead*MSSLspeed, ForceMode2D.Force);
    }
    void MSSLonTGTbail()
    {
        if(GameObject.FindGameObjectWithTag("TGT").transform.position == MSSL.transform.position)
        {
            Destroy(gameObject);
        }
    }
}
