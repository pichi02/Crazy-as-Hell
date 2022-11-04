using UnityEngine;

public class CursorType : MonoBehaviour
{
    [SerializeField] private Texture2D clickedTexture;
    [SerializeField] private Texture2D normalTexture;
    [SerializeField] private Vector2 cursorHotSpot;
    [SerializeField] private CardsDeck cardsDeck;

    private void Update()
    {
        CardUI selectedCard = cardsDeck.GetSelectedCard();

        if (selectedCard != null)
        {
            Cursor.SetCursor(clickedTexture, cursorHotSpot, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(normalTexture, cursorHotSpot, CursorMode.Auto);
        }
    }
}
