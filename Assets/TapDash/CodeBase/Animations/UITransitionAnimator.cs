using DG.Tweening;
using UnityEngine;

namespace TapDash.CodeBase.Animations
{
    public class UITransitionAnimator
    {
        public void ShowPanel(CanvasGroup canvasGroup, RectTransform defaultPosition, float duration, Ease ease)
        {
            defaultPosition.anchoredPosition = new Vector2(0f, 1000f);
            defaultPosition.DOAnchorPos(Vector2.zero, duration).SetEase(ease);
            canvasGroup.DOFade(1, duration).SetEase(ease);
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }

        public void HidePanel(CanvasGroup canvasGroup, RectTransform rectTransform, float duration, Ease ease)
        {
            rectTransform.DOAnchorPos(new Vector2(0f, 1000f), duration).SetEase(ease);
            canvasGroup.DOFade(0, duration).SetEase(ease);
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }
}