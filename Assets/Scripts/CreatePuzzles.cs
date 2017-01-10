using UnityEngine;

namespace Assets.Scripts
{
    public class CreatePuzzles : MonoBehaviour
    {
        public const int WidthCount = 16;
        public const int HeightCount = 16;

        public GameObject OnePuzzle;
        public Sprite[] PuzzleSprites;
        public static string[] PuzzlePicture = new string[WidthCount * HeightCount];

        void Start ()
        {
            var k = 0;
            for (var i = 0; i < HeightCount; i++)
            {
                for (var j = 0; j < WidthCount; j++)
                {
                    var onePuzzle = Instantiate(OnePuzzle, new Vector3(-3.15f + j * 0.42f, 7.15f - i * 0.42f, 3.88f), Quaternion.identity) as GameObject;
                    if (onePuzzle == null) continue;
                    var sr = onePuzzle.transform.GetChild(0).GetComponent<Renderer>() as SpriteRenderer;
                    PuzzlePicture[k] = string.Empty;
                    if (sr != null) sr.sprite = PuzzleSprites[k++];
                }
            }
        }
    }
}
