using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareCrow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float range;
    [SerializeField] LayerMask Bird;
    [SerializeField] float duration;
    float count=0;
    GameObject Player;

    void Start()
    {
        Player=GameObject.FindGameObjectWithTag("Player");
        Destroy(gameObject, duration);
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position,range,Bird);
        foreach(Collider bird in colliders){
            if(!bird.GetComponent<BirdEnemy>().run)
                bird.transform.forward=-bird.transform.forward;
            bird.GetComponent<BirdEnemy>().run=true;
        }
        if(count>=duration){
            count=0;
            Player.GetComponent<Farming>().FarmTile.GetComponent<TileInfo>().isSC=false;
        }
        count+=Time.deltaTime;

    }   

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position,range);
    }
}
