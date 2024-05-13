using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class EyeGazeController : MonoBehaviour
{
    public GameObject cube;
    OVREyeGaze eyeGaze;
    //public string eye_data_file_path = @"c:\Users\UTENTE\Desktop";
    string eye_data_file_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    public float rotX;
    public float rotY;
    public float rotZ;

    // Start is called before the first frame update
    void Start()
    {
        eyeGaze = GetComponent<OVREyeGaze>();
    }

    // Update is called once per frame
    void Update()
    {
        if (eyeGaze == null) return;

        if (eyeGaze.EyeTrackingEnabled)
        {
            cube.transform.rotation = eyeGaze.transform.rotation;
            rotX = eyeGaze.transform.rotation.x;
            rotY = eyeGaze.transform.rotation.y;
            rotZ = eyeGaze.transform.rotation.z;
            string[] rots = {rotX.ToString(),rotY.ToString(),rotZ.ToString()};
            File.AppendAllLines(Path.Combine(eye_data_file_path, "eye_data.txt"), rots);
        }
    }
}
