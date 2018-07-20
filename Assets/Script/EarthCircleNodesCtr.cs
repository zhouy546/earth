using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EarthCircleNodesCtr : MonoBehaviour {

    public float time;
    public float distance;
    public static EarthCircleNodesCtr instance;
    public Transform sphereTransform;
    public Vector3 sphereRotateAngle;
    public Transform XRotTransform;
    public List<EarthCircleNode> earthCircleNodes = new List<EarthCircleNode>();
	// Use this for initialization
	void Start () {
        Initialization();

    }

    public void Initialization() {

        if (instance == null) {

            instance = this;

        }

        XRotTransform = this.GetComponent<Transform>();

        earthCircleNodes = this.GetComponentsInChildren<EarthCircleNode>().ToList();


        foreach (var item in earthCircleNodes)
        {
            item.Initializtion();
        }

        RotateAroundsphere();
    }

    LTDescr RotateLTDescr;
    public void RotateAroundsphere() {
        RotateLTDescr= LeanTween.rotateAround(sphereTransform.gameObject, Vector3.up, -360f, time).setOnUpdate(delegate (float value) {
            sphereRotateAngle =new Vector3(0, sphereTransform.eulerAngles.y,0);
        }).setOnComplete(delegate ()
        {
            RotateAroundsphere();

            RotateLTDescr = null;
        });
    }

    public void RotateSphereMesh(Vector3 Angel) {
        LeanTween.rotateLocal(sphereTransform.gameObject, Angel, 1f);
    }

    public void RotateXRot(Vector3 Angel, Action action=null) {
        LeanTween.rotateLocal(XRotTransform.gameObject, Angel, 1f).setOnComplete(delegate () {
            if (action != null) {
                action();
            }
        });

    }

    public void ResetBack()
    {
       // RotateSphereMesh(sphereRotateAngle);
        RotateXRot(Vector3.zero, RotateAroundsphere);

    }

    public void cancelRotatel() {
        if (RotateLTDescr != null)
        LeanTween.cancel(RotateLTDescr.id);
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            foreach (var item in earthCircleNodes)
            {
                if (item.name == "test") {
                    item.MoveToCamera();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
            ResetBack();

    }
}
