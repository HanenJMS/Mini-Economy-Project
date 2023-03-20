using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Job : MonoBehaviour
{
    public string preCondition;
    public string postCondition;
    public JobStatus currentStatus = JobStatus.Incomplete;
    public JobType jobType = JobType.Hunt;

}
