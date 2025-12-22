using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

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
        
        public void ShowLosePanel(RectTransform panel, RectTransform restartButton, float duration)
        {
            panel.gameObject.SetActive(true);

            panel.sizeDelta = Vector2.zero;
            restartButton.localScale = Vector3.zero;

            DOTween.Sequence()
                .SetUpdate(true)
                .Append(panel.DOSizeDelta(new Vector2(860, 1710), duration).SetEase(Ease.OutBack))
                .Join(restartButton.DOScale(1f, duration).SetEase(Ease.OutBack));
        }

        public void HideLosePanel(RectTransform panel, float duration)
        {
            panel.DOSizeDelta(Vector2.zero, duration).SetEase(Ease.InBack);
            panel.gameObject.SetActive(false);
        }
    }
}