using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementData : MonoBehaviour {

    Vector3 accelValues;
    Vector3 gyroValues;

    [SerializeField] Text AccelX;
    [SerializeField] Text AccelY;
    [SerializeField] Text AccelZ;

    [SerializeField] Text GyroX;
    [SerializeField] Text GyroY;
    [SerializeField] Text GyroZ;

    float lowPassFilterFactor = 1.0f / 60.0f;
    float shakeDetectionThreshold = 1f;
    Vector3 lowPassValue;

    public bool isShaking;

	void Start () {
        lowPassValue = Input.acceleration;
	}
	
	void Update () {
        accelValues = Input.acceleration;
        gyroValues = Input.gyro.attitude.eulerAngles;
        isShaking = ShakeCheck();
	}

    private void LateUpdate()
    {
        AccelX.text = "Accel x: " + accelValues.x.ToString("F2");
        AccelY.text = "Accel y: " + accelValues.y.ToString("F2");
        AccelZ.text = "Accel z: " + accelValues.z.ToString("F2");

        GyroX.text = "Gyro x: " + gyroValues.x.ToString("F2");
        GyroY.text = "Gyro y: " + gyroValues.y.ToString("F2");
        GyroZ.text = "Gyro z: " + gyroValues.z.ToString("F2");
    }

    bool ShakeCheck(){
        lowPassValue = Vector3.Lerp(lowPassValue, accelValues, lowPassFilterFactor);
        Vector3 changeInAccel = accelValues - lowPassValue;
        if ( changeInAccel.sqrMagnitude >= shakeDetectionThreshold )
        {
            return true;
        }
        else{
            return false;
        }
    }
}
