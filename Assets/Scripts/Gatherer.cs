using UnityEngine;
using UnityEngine.AI;

public class Gatherer : MonoBehaviour
{
    Resource target = null;
    NavMeshAgent agent;
    Inventory inventory;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        inventory = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            foreach (Resource woods in FindObjectsOfType<Resource>())
            {

            }
            return;
        }
        else if (target != null)
        {
            agent.SetDestination(target.transform.position);
        }
        if (Vector3.Distance(this.transform.position, target.transform.position) < 2f)
        {
            Item item = target.GetComponent<Item>();
            if(item != null)
            {
                inventory.AddItem(item);
            }
            target = null;
        }
    }
}
