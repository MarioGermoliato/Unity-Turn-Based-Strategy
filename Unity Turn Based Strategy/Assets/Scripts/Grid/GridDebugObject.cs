using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridDebugObject : MonoBehaviour
{
    [SerializeField] private TMP_Text gridDebugObjectText;

    private object gridObject;


    protected virtual void Update()
    {
        gridDebugObjectText.text = gridObject.ToString();
    }
    
    public virtual void SetGridObject(object gridObject)
    {
        this.gridObject = gridObject;
    }

}
