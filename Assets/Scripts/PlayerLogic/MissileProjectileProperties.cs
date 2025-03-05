using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MissileProjectileProperties : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int damage;
    private Rigidbody rb;
    private int speed = 10;
    private int rotateSpeed = 200;
    private float maxDistancePredict = 100;
    private float minDistancePredict = 5;
    private float maxTimePrediction = 5;
    private float deviationAmount = 10;
    private float deviationSpeed = 10;
    public GameObject targetGO;
    private Vector3 deviatedPrediction;
    private Vector3 standardPrediction;

    //public void InitMissileProperties(int missileDamage, int missileSpeed, int missileRotateSpeed, float missileMaxDistancePredict, float missileMinDistancePredict, float missileMaxTimePrediction, float missileDeviationAmount, float missileDeviationSpeed, GameObject target)
    //{
    //    damage = missileDamage;
    //    speed = missileSpeed;
    //    rotateSpeed = missileRotateSpeed;
    //    maxDistancePredict = missileMaxDistancePredict;
    //    minDistancePredict = missileMinDistancePredict;
    //    maxTimePrediction = missileMaxTimePrediction;
    //    deviationAmount = missileDeviationAmount;
    //    deviationSpeed = missileDeviationSpeed;
    //    targetGO = target;
    //}

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (targetGO == null)
        {
            Destroy(gameObject);
            return;
        }
        rb.linearVelocity = transform.forward * speed;
        float leadTimePercentage = Mathf.InverseLerp(minDistancePredict, maxDistancePredict, Vector3.Distance(transform.position, targetGO.transform.position));

        PredictMovement(leadTimePercentage);

        AddDeviation(leadTimePercentage);

        RotateRocket();
    }

    private void PredictMovement(float leadTimePercentage)
    {
        float predictionTime = Mathf.Lerp(0, maxTimePrediction, leadTimePercentage);
        standardPrediction = targetGO.GetComponent<Rigidbody>().position + targetGO.GetComponent<Rigidbody>().linearVelocity * predictionTime;
    }

    private void AddDeviation(float leadTimePercentage)
    {
        Vector3 deviation = new Vector3(Mathf.Cos(Time.time * deviationSpeed), 0, 0);

        Vector3 predictionOffset = transform.TransformDirection(deviation) * deviationAmount * leadTimePercentage;

        deviatedPrediction = standardPrediction + predictionOffset;
    }
    private void RotateRocket()
    {
        Vector3 heading = deviatedPrediction - transform.position;
        Quaternion rotation = Quaternion.LookRotation(heading);
        rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed * Time.deltaTime));
    }
}
