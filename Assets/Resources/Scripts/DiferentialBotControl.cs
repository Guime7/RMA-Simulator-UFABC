using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiferentialBotControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float wheelRadius = 0.017f; //Raio da roda em metros
    public float bodyRadius = 0.05f; //Raio do corpo do rob� em metros
    public float leftWheelSpeed = 0.0f;
    public float rightWheelSpeed = 0.0f;
    public GameObject robotChassis;

    public float deltaT = 1f; //passo da opera��o

    float cos_theta = 0, sin_theta = 0;

    float theta = 0;

    float xAtual, xAnterior, yAtual, yAnterior, anguloAnterior = 0;

    //sensor de colisao
    private BumperSensor bumperSensor;
   

    void Start()
    {    
        InvokeRepeating("Main", 0.1f, deltaT);   
    }
  
    void Main()
    {
        //inicializa o sensor de colisao
        bumperSensor = FindObjectOfType<BumperSensor>();
        float v;
        float omega;
        if(bumperSensor.colisao == true){
            v = 0;
            omega = 0;
        } else {
            v = -1 * FowardSpeed();
            omega = GetOmega();
        }
       
            xAtual = xAnterior + (v * cos_theta * deltaT);
            yAtual = yAnterior + (v * sin_theta * deltaT);
            cos_theta = Mathf.Cos(theta);
            sin_theta = Mathf.Sin(theta);


            xAnterior = xAtual;
            yAnterior = yAtual;
            anguloAnterior = theta;

            //movimentacao
            robotChassis.transform.position = new Vector3(xAtual, 0, yAtual);
            robotChassis.transform.Rotate(0, (-(omega * deltaT) * Mathf.Rad2Deg), 0);

            theta = anguloAnterior + (omega * deltaT);
      
        
    }

    float FowardSpeed()
    {
        float speed = 0;
        speed = ((leftWheelSpeed * wheelRadius) / 2) + ((rightWheelSpeed * wheelRadius) / 2);
        return speed;
    }

    float GetOmega()
    {
        float t = ((leftWheelSpeed * wheelRadius) - (rightWheelSpeed * wheelRadius)) / (2 * bodyRadius);

        return t;
    }
 
}
