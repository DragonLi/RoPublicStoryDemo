using UnityEngine;

namespace Fungus
{
    /// <summary>
    /// Custom by Franky
    /// </summary>
    [CommandInfo("Sprite", 
        "Show Sprites Under a GameObject", 
        "Makes sprites visible / invisible by setting the color alpha.")]
    [AddComponentMenu("")]
    [ExecuteInEditMode]
    public class ShowGameObject:Command
    {
        [Tooltip("Game object where to search sprites.")]
        [SerializeField] protected GameObjectData _sourceObject;

        [Tooltip("Make the sprite visible or invisible")]
        [SerializeField] protected BooleanData _visible = new BooleanData(false);

        protected virtual void SetSpriteAlpha(SpriteRenderer spRenderer, bool visible)
        {
            var spriteColor = spRenderer.color;
            spriteColor.a = visible ? 1f : 0f;
            spRenderer.color = spriteColor;
        }

        public override void OnEnter()
        {
            var gameObj = _sourceObject.Value;
            if (gameObj != null)
            {
                gameObj.SetActive(true);
                var visible = _visible.Value;
                foreach (var sr in gameObj.GetComponentsInChildren<SpriteRenderer>())
                {
                    SetSpriteAlpha(sr, visible);
                }
            }

            Continue();
        }

        public override string GetSummary()
        {
            if (_sourceObject.Value == null)
            {
                return "Error: No sprite renderer selected";
            }

            return _sourceObject.Value.name + " to " + (_visible.Value ? "visible" : "invisible");
        }

        public override Color GetButtonColor()
        {
            return new Color32(221, 184, 169, 255);
        }
    }
}