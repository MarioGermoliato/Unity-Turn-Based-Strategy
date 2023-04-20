using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridDebugObject : MonoBehaviour
{
    [SerializeField] private TMP_Text gridDebugObjectText;

    private GridObject gridObject;


    private void Update()
    {
        gridDebugObjectText.text = gridObject.ToString();
    }
    
    public void SetGridObject(GridObject gridObject)
    {
        this.gridObject = gridObject;
    }

}
