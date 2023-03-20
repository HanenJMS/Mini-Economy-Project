using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobFactory : MonoBehaviour
{
    [SerializeField] int jobsMax = 10;
    [SerializeField] int jobsRunning = 0, jobsIdle = 0;
    [SerializeField] List<Job> jobs = new List<Job>();
    //create jobs
    //jobs need a target or target type, job type, job quota, job reward or punishment
    public void AddJob(Job job, Merchant client)
    {

    }
    public void RemoveJob(Job job, Merchant client)
    {

    }
}
