using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 10;
        float y = Input.GetAxis("Vertical") * Time.deltaTime *10;
        float z = Input.GetAxis("Mouse ScrollWheel") * 10;

        if (Camera.main.orthographicSize + z <= 3)
        {
            z= 0;
        }
        Camera.main.orthographicSize = Camera.main.orthographicSize + z;
        transform.Translate(new Vector3(x, y, 0));
    }
}
