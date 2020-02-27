using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class commentComponent : MonoBehaviour
{
    [Header("Comments")]
    [Tooltip("Comments left for Inspector")]
    [TextArea]
    public string leaveCommentsHere;

    void Start() {/*This method is here for clearing errors*/}
}