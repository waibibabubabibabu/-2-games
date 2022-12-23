using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class rotation : MonoBehaviour
{
    public float rotationSpeed=20f;
    void Update()
    {
        //gameObject.transform.Rotate(Vector3.forward * rotationSpeed);

        /*gameObject.GetComponent<RectTransform>().localRotation = new Quaternion(
            gameObject.GetComponent<RectTransform>().localRotation.x,
            gameObject.GetComponent<RectTransform>().localRotation.y,
            gameObject.GetComponent<RectTransform>().localRotation.z + Time.deltaTime * rotationSpeed,
            0
            );
        */
        this.transform.Rotate(Vector3.forward*Time.deltaTime * rotationSpeed);
    }
}
