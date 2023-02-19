using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BirdEnemy : MonoBehaviour
{
    
    [SerializeField] float radius;
    [SerializeField] LayerMask ground;
    bool destinationSet = false;
    bool attacking=false;
    [SerializeField] float speed;
    Vector3 dir = new Vector3();

    [SerializeField] float damageDelay;
    float delay;

    public bool run=false;
    Vector3 destination= new Vector3();

    [SerializeField] AudioSource flyaway;

    GameObject Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        delay=damageDelay;
        dir = (new Vector3(0,transform.position.y,0) - transform.position).normalized;
        transform.LookAt(new Vector3(0,transform.position.y,0));
        // AM.Play("BirdCry");
    }

    // Update is called once per frame
    void Update()
    {
        if(!run&&Vector3.Magnitude(transform.position-Player.transform.position)<=10f){
            transform.forward=-transform.forward;
            run=true;
        }
        SetDestination();
        if (!run&&!destinationSet)
        {
            transform.position += dir * speed * Time.deltaTime;
            
            search();
        }

        if(!run&&attacking){
            AttackCrop();
        }
        if(run){
            RunAway();
            
        }
        
    }

    void search()
    {
        Collider[] tiles = Physics.OverlapSphere(transform.position, radius, ground);
            
        foreach (Collider tile in tiles)
        {
            if (tile.GetComponent<TileInfo>() != null)
            {
                if (tile.GetComponent<TileInfo>().cropType.Length > 0)
                {
                    destination=tile.transform.position;
                    destinationSet = true;
                    break;
                }
            }
        }
    }

    void SetDestination(){
        if(destination!=Vector3.zero){
            transform.LookAt(new Vector3(destination.x,transform.position.y,destination.z));
            Vector3 dir = new Vector3();
            dir = (destination-transform.position);
            dir.y=0;
            dir=dir.normalized;
            
            transform.position+=dir*speed*Time.deltaTime;
        }
        if((transform.position-destination).magnitude<=5.1f){
            destination=Vector3.zero;
            attacking=true;
        }
    }

    void AttackCrop(){
        if(Physics.Raycast(transform.position,Vector3.down,out RaycastHit hit, ground)){
            if(hit.collider.GetComponent<TileInfo>()!=null){
            if(delay>=damageDelay){
                delay=0;
                hit.collider.GetComponent<TileInfo>().giveDamage(10);
            }
            delay+=Time.deltaTime;
            if(hit.collider.GetComponent<TileInfo>().health<=0){
                // Debug.Log("Attack");    
                attacking=false;
                destinationSet=false;
            }
            }
        }
        
    }

    public void RunAway(){
        transform.position+=transform.forward*2*speed*Time.deltaTime;
        Destroy(gameObject,3f);
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position,radius);
    }
}
