using UnityEditor;
using UnityEngine;

public class EditorTool : EditorWindow
{
    [MenuItem("Tools/Editor Tool")]
    public static void ShowWindow()
    {
        GetWindow<EditorTool>("Editor Tool");
    }
    private void OnEnable()
    {   
        SceneView.duringSceneGui += OnScene;
    }

    private void OnDisable()
    {
        SceneView.duringSceneGui -= OnScene;
    }

    private void OnScene(SceneView scene)
    {
        Vector2 mousePos = Event.current.mousePosition;

        // Adjust for correct resolution and orientation
        float ppp = EditorGUIUtility.pixelsPerPoint;
        mousePos.y = scene.camera.pixelHeight - mousePos.y * ppp;
        mousePos.x *= ppp;

        Ray ray = scene.camera.ScreenPointToRay(mousePos);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        if (Event.current.type == EventType.MouseDown && Event.current.button == 0) // LeftMouseDown
        {
             Debug.Log(hit.point);
        }
    }
}
