using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthCircleNode : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void Initializtion() {
        LeanTween.scale(this.gameObject, this.transform.localScale * 1.2f, .5f).setLoopPingPong();

        SetPosition();

        transform.LookAt(EarthCircleNodesCtr.instance.sphereTransform);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetPosition() {
        Vector3 temp = (this.transform.position - EarthCircleNodesCtr.instance.sphereTransform.position).normalized;

       this.transform.position = EarthCircleNodesCtr.instance.distance*temp + EarthCircleNodesCtr.instance.sphereTransform.position ;
    }
}
