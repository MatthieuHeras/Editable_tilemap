using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Bow : MonoBehaviour
{

    public Transform unit;
    public GameObject projectile;
    public Transform shotPoint;

    Vector3 mousePosition;
    float cameraDistance = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.position = unit.position;
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraDistance));

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Rad2Deg * Mathf.Atan2(mousePosition.y - unit.position.y, mousePosition.x - unit.position.x)));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            throw_arrow();
        }
    }

    public void throw_arrow()
    {
        Instantiate(projectile, shotPoint.position, transform.rotation);
    }
}
