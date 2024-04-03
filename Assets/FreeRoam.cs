using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class FreeRoam : MonoBehaviour
{
    private NavMeshAgent _navAgent;
    public bool isMoving = false;
    [SerializeField] private float areaOfMove = 4f;

    // Start is called before the first frame update
    void Start()
    {
        _navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == false)
        {
            StartCoroutine(Move());
        }
    }

    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;

        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }

        transform.LookAt(finalPosition);

        return finalPosition;
    }

    private IEnumerator Move()
    {
        isMoving = true;

        _navAgent.SetDestination(RandomNavmeshLocation(areaOfMove));

        yield return new WaitForSeconds(5f);
        isMoving = false;
        yield return null;
    }
}
