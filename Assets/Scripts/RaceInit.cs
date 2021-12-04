using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceInit : MonoBehaviour
{
    public int carCount;

    public GameObject carTemplate;
    private GameObject start;


    void Awake()
    {
        if (carCount < 1)
        {
            Debug.LogError("carCount has to be greater than 0");
        }

        //get startline prefab
        start=GameObject.FindGameObjectWithTag("Start");
       

        GenerateNewCars(carCount);  // then generate the rest of the cars

        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void GenerateNewCars(int count)
    {
        // creates new car objects, count is the number of cars to create
        for (int i = 0; i < count; i++)
        {
            // get random 2d position that isn't too close to other objects
            //Vector2 randomPosition = Helpers.GetRandomPosition(2f);

            Vector2 startPosition=start.transform.position;  

            //
            startPosition.y-=carTemplate.transform.localScale.x*2;  
                    
            // random rotation
            Quaternion startRotation = start.transform.rotation;

            // create new car
            GameObject newCar = Instantiate(carTemplate, startPosition, startRotation);

            newCar.tag = "Car";
            newCar.GetComponent<CarController>().name = "Car" + i;

            // set car color to random color
            newCar.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }

        Debug.Log("Generated " + count + " cars");
    }




}