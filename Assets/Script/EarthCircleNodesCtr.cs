using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EarthCircleNodesCtr : MonoBehaviour {
   public float distance;
   public static EarthCircleNodesCtr instance;
   public Transform sphereTransform;
   public List<EarthCircleNode> earthCircleNodes = new List<EarthCircleNode>();
	// Use this for initialization
	void Start () {
        Initialization();

    }

    public void Initialization() {

        if (instance == null) {

            instance = this;

        }

        sphereTransform = this.GetComponent<Transform>();

        earthCircleNodes = this.GetComponentsInChildren<EarthCircleNode>().ToList();


        foreach (var item in earthCircleNodes)
        {
            item.Initializtion();
        }

        RotateSelf();
    }

    LTDescr RotateLTDescr;

    public void RotateSelf() {
        RotateLTDescr= LeanTween.rotateAround(this.gameObject, Vector3.up, -360f, 50f).setOnComplete(delegate ()
        {
            RotateSelf();

            RotateLTDescr = null;
        });
    }

    public void cancelRotatel() {
        LeanTween.cancel(RotateLTDescr.id);
    }

	// Update is called once per frame
	void Update () {

	}
}
