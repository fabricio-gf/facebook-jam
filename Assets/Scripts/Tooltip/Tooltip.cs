using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    public float timeUntilTooltip = 1f;

    [TextArea]
    public string tooltip;
    public Vector3 tooltipPositionOffset;
    public void OnPointerEnter(){
        StartCoroutine(tooltipTimer());
    }

    public void OnPointerExit(){
        StopCoroutine(tooltipTimer());
    }

    IEnumerator tooltipTimer(){
        yield return new WaitForSeconds(timeUntilTooltip);
        TooltipBox.instance.EnableTooltip(transform.position + tooltipPositionOffset, tooltip);
    }
}
