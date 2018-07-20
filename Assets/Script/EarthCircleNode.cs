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

    public void MoveToCamera() {

        EarthCircleNodesCtr.instance.cancelRotatel();

        Vector3 SphereMeshRot = new Vector3(0, EarthCircleNodesCtr.instance.sphereRotateAngle.y + MeasureYrot(), 0);
       
        EarthCircleNodesCtr.instance.RotateSphereMesh(SphereMeshRot);


        Vector3 XRot = new Vector3(EarthCircleNodesCtr.instance.XRotTransform.localRotation.eulerAngles.x+MeasureXrot(), 0, 0);
       
        EarthCircleNodesCtr.instance.RotateXRot(XRot);
    }

    private float MeasureYrot() {

        Vector2 NodeXZPos = new Vector2(this.transform.position.x, transform.position.z);

        Vector2 SphereXZPos = new Vector2(EarthCircleNodesCtr.instance.sphereTransform.position.x, EarthCircleNodesCtr.instance.sphereTransform.position.z);

        float topDis = (NodeXZPos - SphereXZPos).magnitude;

        float temp = Mathf.Abs( transform.position.z - EarthCircleNodesCtr.instance.sphereTransform.position.z);

        float rotY =Mathf.Rad2Deg*Mathf.Acos(temp / topDis);

        if (transform.position.x > SphereXZPos.x && transform.position.z < SphereXZPos.y)
        {
            return rotY;
        }
        else if (transform.position.x > SphereXZPos.x && transform.position.z > SphereXZPos.y)
        {
            return (90-rotY + 90);
        }
        else if (transform.position.x < SphereXZPos.x && transform.position.z < SphereXZPos.y)
        {
            return -rotY;
        }
        else if (transform.position.x < SphereXZPos.x && transform.position.z > SphereXZPos.y)
        {
            return -(90-rotY + 90);
        }

        return 0;
    }

    private float MeasureXrot() {

        Vector3 NodePos = this.transform.position;

        Vector3 SpherePos = EarthCircleNodesCtr.instance.sphereTransform.position;

        float Ldis = (NodePos - SpherePos).magnitude;

        float Ydis = Mathf.Abs(NodePos.y - SpherePos.y);

        float rotX = Mathf.Rad2Deg * Mathf.Asin(Ydis / Ldis);

        if (transform.position.y > SpherePos.y)
        {
            return -rotX;
        } else if (transform.position.y < SpherePos.y) {
            return rotX;
        }
        return 0;
    }
}
