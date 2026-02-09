using UnityEngine;
using UnityEngine.UIElements;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        private Label scoreLabel;
        private int score;

        private Label livesLabel;
        private int lives;

        // Start is called before the first frame update
        void Start()
        {
            var uiDocument = GetComponent<UIDocument>();
            var root = uiDocument.rootVisualElement;

            // Score
            scoreLabel = root.Q<Label>("ScoreLabel");
            score = 0;
            UpdateScore(score);

            // Lives
            livesLabel = root.Q<Label>("LivesLabel");
            lives = 4;
            livesLabel.text = $"Lives: {lives}";
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void UpdateScore(int points)
        {
            score += points;
            scoreLabel.text = $"Score: {score}";
        }

        public void UpdateLives(bool isAddLife)
        {
            if (isAddLife)
            {
                lives++;
            }
            else
            {
                lives--;
            }

            livesLabel.text = $"Lives: {lives}";
        }

        public int GetLives() => lives;
    }
}
