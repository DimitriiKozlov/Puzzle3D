using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class MovePuzzle : MonoBehaviour
    {
        private const float Distance = 7;
        public CreatePuzzles CreatePuzzles;

        void OnMouseDrag()
        {

            var puzzleY = Input.mousePosition.y > 20 ? Input.mousePosition.y : 20f;

            var mousePosition = new Vector3(Input.mousePosition.x, puzzleY, Distance);
            var objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            transform.position = objPosition;

            var rb = GetComponent<Rigidbody>();

            if (!rb.isKinematic)
                return;

            var cellPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 7.77f));
            var i = Convert.ToInt32(Math.Round((7.15f - cellPosition.y) / 0.42f));
            var j = Convert.ToInt32(Math.Round((cellPosition.x + 3.15f) / 0.42f));
            var n = j + CreatePuzzles.WidthCount * i;
            CreatePuzzles.PuzzlePicture[n] = string.Empty;
            rb.isKinematic = false;
            rb.useGravity = true;
        }
        void OnMouseUp()
        {
            var cellPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 7.77f));
            var i = Convert.ToInt32(Math.Round((7.15f - cellPosition.y) / 0.42f));
            var j = Convert.ToInt32(Math.Round((cellPosition.x + 3.15f) / 0.42f));
            var n = j + 16 * i;

            if ((i < 0) || (i > 15) || (j < 0) || (j > 15))
                return;

            if (CreatePuzzles.PuzzlePicture[n] != string.Empty)
                return;

            var sr = transform.GetChild(0).GetComponent<Renderer>() as SpriteRenderer;

            if (sr != null) CreatePuzzles.PuzzlePicture[n] = sr.name;
            transform.position = new Vector3(-3.15f + j * 0.42f, 7.15f - i * 0.42f, 3.88f);

            var rb = GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.isKinematic = true;

            //if (_checkCompletePicture())
            //{
            //    print("Great Job !!!");
            //}
        }


        private bool _checkCompletePicture()
        {
            for (var i = 0; i < CreatePuzzles.PuzzlePicture.Length; i++)
            {
                var sprite = CreatePuzzles.PuzzleSprites[i];
                if (CreatePuzzles.PuzzlePicture[i] != sprite.name)
                    return false;
            }
            return true;
        }
    }
}
