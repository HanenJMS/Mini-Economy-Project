using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobList : MonoBehaviour
{
    private List<Job> jobsList = new List<Job>();
    private void Start()
    {
        FindClients();
    }
    internal void RunCurrentJob()
    {

    }

    private void FindClients()
    {
        foreach (ClientManager cm in FindObjectsOfType<ClientManager>())
        {
            if (Vector3.Distance(this.transform.position, cm.transform.position) < 10f)
            {

            }
        }
    }
    private void JobIsAchievable()
    {
    }
}
