using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FieldOfView))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        FieldOfView fov = (FieldOfView)target;
        Handles.color = Color.green;
        Handles.DrawWireArc(fov.transform.position, Vector3.forward, Vector3.right, 360, fov.ViewRad);
        Vector3 viewAngleA = fov.DirFromAngle(-fov.viewAng / 2, false);
        Vector3 viewAngleB = fov.DirFromAngle(fov.viewAng / 2, false);

        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleA * fov.ViewRad);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleB * fov.ViewRad);

        Handles.color = Color.green;
        foreach (Transform visibleTarget in fov.visibleTargets)
        {
            Handles.DrawLine(fov.transform.position, visibleTarget.position);

        }
    }
}
