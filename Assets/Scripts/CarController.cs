using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarController : MonoBehaviour
{
    private GameObject carPreview;
    private Rigidbody2D carRb;
    private bool rotationPreview = false;
    private Quaternion initialRotation;
    private bool newCar=true;

    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        carRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RotationPreview(float speed, float angle)
    {
        if (!rotationPreview && newCar) 
        {
            RotationPreviewStart();
        }

        else{
            transform.rotation=initialRotation;
            carRb.transform.Rotate(0, 0, angle);
        }

        if (newCar)
        {
            // save original car color
            GetComponent<SpriteRenderer>().color = new Color(1f, .5f - speed / 2, .5f - speed / 2);
        }
    }


    private void RotationPreviewStart()
    {
        initialRotation=transform.rotation;
        GetComponent<CapsuleCollider2D>().enabled = false;
        rotationPreview = true;
        originalColor = GetComponent<SpriteRenderer>().color;
    }

    private void RotationPreviewEnd()
    {
        // destroys rotation preview
        GetComponent<CapsuleCollider2D>().enabled = true;
        rotationPreview = false;
        newCar=false;

        // restore original car color 
        GetComponent<SpriteRenderer>().color = originalColor;
    }

    // rotation coroutine
    public IEnumerator MoveAnimate(KeyboardController keycontroll, float duration, float angle)
    {
        // ends preview, moves car to new position and rotates it to new angle at the same time
        RotationPreviewEnd();

        // first rotate
        float time = 0.0f;

        //move forward
        while (time < duration)
        {
            time += Time.deltaTime;
            carRb.AddForce(transform.up * 5);
            yield return null;
        }

        // wait 2 seconds for the car to stop before switching to the next car
        yield return new WaitForSeconds(2);

        newCar=true;
        keycontroll.NextCar();

    }

    public void DebugMove(float thrust)
    {
        // debug use only
        carRb.AddForce(transform.up * thrust);
    }

    public void DebugRotate(float angle)
    {
        // debug use only
        carRb.transform.Rotate(0, 0, angle);
    }
}
