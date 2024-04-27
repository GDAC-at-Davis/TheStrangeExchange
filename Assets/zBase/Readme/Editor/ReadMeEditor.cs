using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ReadMe))]
public class ReadMeEditor : Editor
{
    private GUIStyle _bodyStyle;
    private GUIStyle _headerStyle;
    private GUIStyle _subHeaderStyle;

    private void OnEnable()
    {
        _headerStyle = new GUIStyle
        {
            fontSize = 24,
            fontStyle = FontStyle.Bold,
            margin = new RectOffset(0, 0, 10, 10),
            wordWrap = true
        };
        _headerStyle.normal.textColor = Color.white;

        _subHeaderStyle = new GUIStyle
        {
            fontSize = 18,
            fontStyle = FontStyle.Bold,
            margin = new RectOffset(0, 0, 10, 10),
            wordWrap = true
        };
        _subHeaderStyle.normal.textColor = new Color(0.9f, 0.9f, 0.9f, 1f);

        _bodyStyle = new GUIStyle
        {
            fontSize = 14,
            margin = new RectOffset(0, 0, 10, 10),
            wordWrap = true
        };
        _bodyStyle.normal.textColor = new Color(0.8f, 0.8f, 0.8f, 1f);
    }

    public override void OnInspectorGUI()
    {
        // draw solid color background
        Rect rect = GUILayoutUtility.GetRect(0, 0);
        rect.width = EditorGUIUtility.currentViewWidth;
        rect.height = 10000;
        EditorGUI.DrawRect(rect, new Color(0.2f, 0.2f, 0.2f, 1));

        // Image banner
        var tex = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/zBase/Readme/Editor/fantasyshop.jpg");
        if (tex != null)
        {
            // image rect
            float aspect = (float)tex.width / tex.height;
            float width = EditorGUIUtility.currentViewWidth;
            float height = width / aspect;
            GUILayout.Label(tex, GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true), GUILayout.Width(width),
                GUILayout.Height(height));
        }

        if (GUILayout.Button("Image credits", EditorStyles.linkLabel))
        {
            Application.OpenURL("https://yangsh.artstation.com/projects/mq5GNd\n");
        }

        // indent group
        EditorGUI.indentLevel++;

        EditorGUILayout.LabelField("Thanks for participating in the GDACx3D Enthusiasts Collab :D", _headerStyle);

        EditorGUILayout.LabelField("How to do:", _subHeaderStyle);

        EditorGUILayout.LabelField(
            "1. You should have chosen one of the models created by the 3D Enthusiasts club. " +
            "Make a new folder under 'Assets' named after whatever strange item you're bringing to life",
            _bodyStyle);

        EditorGUILayout.LabelField(
            "2. Import your model into the folder you just created. " +
            "Everything you add (scripts, materials, shaders, textures, sound effects) should be under this folder or its subfolders",
            _bodyStyle);

        EditorGUILayout.LabelField(
            "3. Look in the 'Scripts: Use Me' folder for scripts that let the player interact with your object. " +
            "You can use these scripts as a starting point for your own scripts. the zBase folder has the core gameplay stuff - don't worry about that unless really want to know",
            _bodyStyle);

        EditorGUILayout.LabelField(
            "4. Do whatever you want with your model!!! Make it explode, move, talk, whatever. Be as fancy or as simple as you want" +
            ". Write your own scripts, or don't code at all - the BubblyMug example doesn't use any extra code! ",
            _bodyStyle);

        EditorGUILayout.LabelField("Remember, the theme is 'Shop of Curiosities', so make something funky!!",
            _subHeaderStyle);

        EditorGUILayout.LabelField(
            "5. Once you're done, try to turn the entire item into a single prefab with everything included. " +
            "Then, right click the folder you made in step 2. and select 'Export Package'. Make sure you only include your folder in the package, and post the package on the Discord server. ",
            _bodyStyle);

        EditorGUILayout.LabelField("Resources:", _subHeaderStyle);

        if (GUILayout.Button("Unity Events Introduction", EditorStyles.linkLabel))
        {
            Application.OpenURL("https://www.youtube.com/watch?v=TWxXD-UpvSg");
        }

        EditorGUI.indentLevel--;
    }
}