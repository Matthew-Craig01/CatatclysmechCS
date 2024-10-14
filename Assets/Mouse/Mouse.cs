using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Utils
{
    public class Mouse : MonoBehaviour
    {
        public Texture2D cursor;
        public Vector2 hotspot = Vector2.zero;

        void Start()
        {
            Cursor.SetCursor(cursor, hotspot, CursorMode.Auto);
        }

        public static Vector2 getDirection()
        {
            //TODO Change to be based on player
            var centre = new Vector2(Screen.width / 2, Screen.height / 2);
            var mousePos = (Vector2)Input.mousePosition;
            var direction = (mousePos - centre).normalized;
            if (direction == Vector2.zero)
            {
                return new Vector2(1, 1);
            }
            return direction;
        }


        public static Vector2 getRelativePosPercent()
        {
            var centre = new Vector2(Screen.width / 2, Screen.height / 2);
            var mousePos = (Vector2)Input.mousePosition;
            var inPixels = mousePos - centre;
            var percent = new Vector2(inPixels.x / Screen.width, inPixels.y / Screen.height);
            return percent;
        }
    }
}
