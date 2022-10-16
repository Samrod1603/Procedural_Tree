using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweens : MonoBehaviour
{
    [SerializeField]
    private Transform targetTransform;
    [Header("Tween related") ]
    [SerializeField, Range(0, 1)]
    private float normalizedTime;
    [SerializeField]
    private float duration = 1;
    [Header("Parameters")]
    [SerializeField]
    private Color initialColor;
    [SerializeField]
    private Color finalColor;


    private Vector3 initialPosition;
    private Vector3 finalPosition;
    private SpriteRenderer spriteRenderer; 


    private float currentTime = 0;
    void Start()
    { 
        StartTween();
        spriteRenderer = GetComponent<SpriteRenderer>();  
    }

    
    void Update()
    {
        normalizedTime = currentTime / duration; 
        transform.position = Vector3.Lerp(initialPosition,finalPosition,normalizedTime * normalizedTime);
        currentTime += Time.deltaTime;
        spriteRenderer.color = Color.Lerp(initialColor,finalColor,normalizedTime * normalizedTime);

        /*if (transform.position == targetTransform.position)
        {
            Debug.Log("Tween ended");
        }*/
        if (currentTime >= 1)
        {
            Debug.Log("Tween ended");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartTween(); 
        }
    }

    private void StartTween()
    {
        currentTime = 0f;
        initialPosition = transform.position;
        finalPosition = targetTransform.position; 
    }
}
