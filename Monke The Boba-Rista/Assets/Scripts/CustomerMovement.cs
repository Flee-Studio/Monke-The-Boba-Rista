using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerMovement : MonoBehaviour
{
    public Vector3 targetPosition;
    public float speed = 2f;
    Animator animator;
    Vector3 currentPosition;
    Vector3 previousPosition;
    SpriteRenderer spriteRenderer;
    public Vector3 exitPosition;
    private Toggle myToggle;

    // Start is called before the first frame update
    void Start()
    {
        myToggle = GetComponentInChildren<Toggle>();

        if (myToggle != null)
		{
            myToggle.onValueChanged.AddListener(OnToggleValueChanged);
		}

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        currentPosition = transform.position;

        if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
		{
            animator.SetBool("isMoving", false);
		}
        else
		{
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            animator.SetBool("isMoving", true);
            if (currentPosition.x > previousPosition.x)
            {
                //Moving right
                spriteRenderer.flipX = true;
            }
            else if (currentPosition.x < previousPosition.x)
			{
                //Moving left
                spriteRenderer.flipX = false;
            }

            previousPosition = currentPosition;
        }
    }

    void OnToggleValueChanged(bool isOn)
	{
        if (isOn)
		{
            Debug.Log("Toggle is switched ON");
            ExecuteFunction();
		}
        else
		{
            Debug.Log("Toggle is switched OFF");
        }
	}

    void ExecuteFunction()
	{
        transform.position = exitPosition;
	}

	private void OnDestroy()
	{
        // Remove the listener when the script is destroyed to avoid memory leaks
        if (myToggle != null)
		{
            myToggle.onValueChanged.RemoveListener(OnToggleValueChanged);
		}
	}
}
