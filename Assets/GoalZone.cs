using UnityEngine;

public class GoalZone : MonoBehaviour
{
    private bool reached;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entró algo: " + other.name);

        if (other.GetComponent<PlayerMovement>() != null)
        {
            reached = true;
            Debug.Log("¡Meta alcanzada!");
        }
    }

    void OnGUI()
    {
        if (!reached)
        {
            return;
        }

        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 100;
        style.alignment = TextAnchor.MiddleCenter;
        style.normal.textColor = Color.white;

        GUI.DrawTexture(new Rect(0, 0, Screen.width, 300), Texture2D.blackTexture);
        GUI.Label(new Rect(0, 0, Screen.width, 300), "¡Lo lograste!", style);
    }
}