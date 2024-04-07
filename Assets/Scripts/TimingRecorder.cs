using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Globalization;

public class TimingRecorder : MonoBehaviour
{
    public Timing timing;
    public string filePath;
    private bool isChecked = false;
    private float startTime;
    private bool isRed;
    public SceneTimer timer;
    
    void Start()
    {
        startTime = Time.timeSinceLevelLoad;
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        //filePath = "/Downloads/TimingRecords.csv";
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Dispose();
        }
    }

    
    void Update()
    {
        if (timing.flashValue == 1){
            isChecked = false;
        }
        if (timing.flashValue == 2 && !isChecked)
        {
            isChecked = true;
            isRed = true;
            float runtime = timer.currentTime;
            
            String timeString = runtime.ToString("F2", CultureInfo.InvariantCulture);
            using (StreamWriter writer = File.AppendText(filePath))
        {
            writer.WriteLine(timeString + ",");
        }
        }
        if (timing.flashValue == 3 && isRed){

            isRed = false;
            float runtime = timer.currentTime;
            String timeString = runtime.ToString("F2", CultureInfo.InvariantCulture);
            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine(timeString + ",");
            }
        }
    }
}
