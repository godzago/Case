using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMashAI : MonoBehaviour
{
    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] GameObject Target;
    NavMeshAgent navMash;
    private Rigidbody rgb;
    

    void Awake()
    {
        navMash = this.gameObject.GetComponent<NavMeshAgent>();
        rgb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        navMash.SetDestination(Target.transform.position);
    }

    // if crash my character add the force the enemy and particle Instantiate 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rgb.AddForce(new Vector3(100,0,100), ForceMode.Force);
            Instantiate(crashParticle, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
            crashParticle.Play();
        }
    }
}
