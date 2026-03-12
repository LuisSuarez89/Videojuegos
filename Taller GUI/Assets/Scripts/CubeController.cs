using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CubeController : MonoBehaviour
{
    public Slider sliderX;
    public Slider sliderY;
    public Slider sliderZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoverEnX(float value){
        var posX = transform.position;
        transform.position = new Vector3 (value,posX.y,posX.z);
    }

    public void MoverEnY(float value){
        var posX = transform.position;
        transform.position = new Vector3 (posX.x,value,posX.z);
    }

    public void MoverEnZ(float value){
        var posX = transform.position;
        transform.position = new Vector3 (posX.x,posX.y,value);
    }

    public void ResetTodo(){
        Vector3 defaultPos = new Vector3 (0,0,0);
        transform.position = defaultPos;
        sliderX.value = 0f;
        sliderY.value = 0f;
        sliderZ.value = 0f;
    }


}
