using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCvSharp;

public class face_detector : MonoBehaviour
{
    public GameObject obj;
    //empty tecture declared//
    WebCamTexture webcamtexture;
    //declare your CascadeClassifier//
    CascadeClassifier cascade;
    // Start is called before the first frame update

    OpenCvSharp.Rect Myface;
    void Start()
    {
       // obj.GetComponent<Renderer>().material.SetTextureScale("_BaseMap", new Vector2(-1, 1));//tries to flip webcam image here//

        //create an array of webcams and load all cameras//
        WebCamDevice[] devices = WebCamTexture.devices;
        //use the camera in the index zero//
        webcamtexture = new WebCamTexture(devices[0].name);
        webcamtexture.Play();
        //to parse the frames to open cv we need a cascade classfy however we need to specify a file path//
        Debug.Log(Application.dataPath + "/OpenCV+Unity/Demo/Face_Detector/haarcascade_frontalface_default.xml");
       //after correct file path is spesified then we can start 
        cascade = new CascadeClassifier(Application.dataPath + "/OpenCV+Unity/Demo/Face_Detector/haarcascade_frontalface_default.xml");

        //cascade = new CascadeClassifier(Application.dataPath );




        //  cascade = new CascadeClassifier("lbpcascade_frontalface.xml"); 
    }

    // Update is called once per frame
    void Update()
    {
        //use the webcam texture as  the render texture//
        // GetComponent<Renderer>().material.mainTexture = webcamtexture;

    

        //new openCv mat stores the current frame //
        Mat frame = OpenCvSharp.Unity.TextureToMat(webcamtexture);

        FindNewFace(frame);
        addrectangle(frame);
    }
    //to detect if theres a new face in the scene if() there is store it as faces//
    void FindNewFace(Mat frame){
        
        var faces = cascade.DetectMultiScale(frame, 1.1f, 2, HaarDetectionType.ScaleImage);
        if (faces.Length >= 1)
        {
            Debug.Log("working");
            Debug.Log("face coordinates are :" + faces[0].Location);
            Myface = faces[0];
        }

       // else
           // Debug.Log("function not working");

    }
    void addrectangle(Mat frame) {
        if (Myface != null) {
            frame.Rectangle(Myface, new Scalar(250, 0, 0), 2);
        }
        Texture newtexture = OpenCvSharp.Unity.MatToTexture(frame);
        GetComponent<Renderer>().material.mainTexture = newtexture;
    }
}
