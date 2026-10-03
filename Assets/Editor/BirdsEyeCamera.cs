using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

// Main Camera'yı zeminin tam üstüne, aşağı bakacak şekilde (kuş bakışı) yerleştirir.
// W = ekranda yukarı (+Z), D = ekranda sağ (+X).
public static class BirdsEyeCamera
{
    [MenuItem("Tools/Bird's Eye Camera")]
    static void Apply()
    {
        var cam = Camera.main;
        if (cam == null) { Debug.LogWarning("Main Camera bulunamadı"); return; }
        Undo.RecordObject(cam.transform, "Bird's Eye Camera");
        cam.transform.position = new Vector3(0f, 20f, 0f);
        cam.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        EditorSceneManager.MarkSceneDirty(cam.gameObject.scene);
        Debug.Log("Kamera kuş bakışına alındı");
    }
}
