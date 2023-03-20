using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAI : MonoBehaviour
{
    JobList jobList;

    private void Start()
    {
        jobList.RunCurrentJob();
    }
}
