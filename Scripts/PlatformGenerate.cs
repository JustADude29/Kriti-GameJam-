using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerate : MonoBehaviour
{
    public GameObject chunk;
    public GameObject Platform;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<21;i++){
            for(int j=0;j<21;j++){
                GameObject tile= Instantiate(chunk,new Vector3(10*i,0,10*j),Quaternion.identity);
                tile.transform.parent=Platform.transform;
            }
        }
    }

    
    
}
