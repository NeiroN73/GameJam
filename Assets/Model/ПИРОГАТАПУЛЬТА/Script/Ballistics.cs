using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballistics : MonoBehaviour {

    public Transform SpawnTransform;
    public Transform TargetTransform;

    public float AngleInDegrees;

    float g = Physics.gravity.y;

    public GameObject Bullet;

	void Update () {
        SpawnTransform.localEulerAngles = new Vector3(-AngleInDegrees, 0f, 0f);

        if (Input.GetMouseButtonDown(0)) {
            Shot();
        }
    }

    public void Shot() {
        Vector3 fromTo = TargetTransform.position - transform.position;
        Vector3 fromToXY = new Vector3(fromTo.x, fromTo.y, 0f);

        transform.rotation = Quaternion.LookRotation(fromToXY, Vector3.up);


        float x = fromToXY.magnitude;
        float z = fromTo.z;

        float AngleInRadians = AngleInDegrees * Mathf.PI / 180;

        float v2 = (g * x * x) / (2 * (z - Mathf.Tan(AngleInRadians) * x) * Mathf.Pow(Mathf.Cos(AngleInRadians), 2));
        float v = Mathf.Sqrt(Mathf.Abs(v2));

        GameObject newBullet = Instantiate(Bullet, SpawnTransform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().velocity = SpawnTransform.forward * v;
    }

}
