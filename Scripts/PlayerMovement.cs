using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask isGround;
    GameObject goToTile;
    NavMeshAgent Player;
    public RaycastHit hit;
    public Animator animator;

    private Material tempMat;
    
    GameObject prevTile;
    void Awake()
    {
        Player = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if(Physics.Raycast(ray,out hit,Mathf.Infinity,isGround)){
                goToTile=hit.collider.gameObject;
                tempMat = new Material(goToTile.GetComponent<Renderer>().material);
                goToTile.GetComponent<Renderer>().material.color=Color.blue;

                Player.SetDestination(goToTile.transform.position);
                
            }


            
        }
        if(Input.GetMouseButtonUp(0)){
            goToTile.GetComponent<Renderer>().material = new Material(tempMat);

        }
        
        animator.SetFloat("speed", Player.velocity.magnitude);


    }

    
}
