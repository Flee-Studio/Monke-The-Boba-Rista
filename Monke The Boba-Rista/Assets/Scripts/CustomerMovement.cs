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
    public Toggle myToggle;
    public bool waitingToDelete = false;
    private CustomerSpawner parentScript;

    // Start is called before the first frame update
    void Start()
    {
        myToggle = GetComponentInChildren<Toggle>();
        parentScript = GetComponentInParent<CustomerSpawner>();

        if (myToggle != null)
		{
            myToggle.onValueChanged.AddListener(OnToggleValueChanged);
		}
        else
		{
            Debug.LogError("Toggle component not found");
		}

        if (parentScript == null)
		{
            Debug.LogError("CustomerSpawner not found in parent.");
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

        if (waitingToDelete && Vector3.Distance(exitPosition, currentPosition) < 0.001f)
		{
            Destroy(gameObject);
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
        targetPosition = exitPosition;
        waitingToDelete = true;
        if (parentScript != null)
		{
            parentScript.NotifyChildDestroyed(gameObject);
		}
	}

	private void OnDestroy()
	{
        // Remove the listener when the script is destroyed to avoid memory leaks
        if (myToggle != null)
		{
            myToggle.onValueChanged.RemoveListener(OnToggleValueChanged);
		}
        Debug.Log(gameObject.name + " was destroyed");
    }
}
