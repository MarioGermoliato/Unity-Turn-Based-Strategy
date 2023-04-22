using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{    
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] float rotateSpeed = 10f;
    [SerializeField] Animator unitAnimator;

    private Vector3 targetPosition;
    private GridPosition gridPosition;


    private void Awake()
    {
        targetPosition = transform.position;
    }

    private void Start()
    {
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(gridPosition, this);
    }

    private void Update()
    {
        float stoppingDistance = .1f;        

        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance )
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position += moveDirection * Time.deltaTime * moveSpeed;

            transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);

            unitAnimator.SetBool("IsWalking", true);
        }
        else
        {
            unitAnimator.SetBool("IsWalking", false);
        }

        
        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        if( newGridPosition != gridPosition)
        { //unit changed grid position
            LevelGrid.Instance.UnitMoveGridPosition(this, gridPosition, newGridPosition);
            gridPosition = newGridPosition;
        }
    }

    public void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }
}
