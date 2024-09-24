using ProjectUnicorn.InteractionSystem;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

/**
 * File: ConversationManager.cs
 * Description: Connects the UI elements and conversation with the player's interaction.
 */

namespace ProjectUnicorn.DialogSystem
{
    public class ConversationManager : MonoBehaviour, IInteractable
    {
        [SerializeField] private Conversation _conversation;

        [SerializeField] private GameObject _conversationUI;
        [SerializeField] private Image _conversationImage;
        [SerializeField] private TextMeshProUGUI _conversationSpeaker;
        [SerializeField] private TextMeshProUGUI _conversationSpeechText;

        private int _conversationCount = 0;

        private void Start()
        {
            ResetUI();
        }

        public void Interact()
        {
            ShowUI();
            UpdateUI(_conversation.Dialog[_conversationCount].CharacterImage, 
                     _conversation.Dialog[_conversationCount].CharacterName, 
                     _conversation.Dialog[_conversationCount].CharacterMessage);
        }

        private void ShowUI()
        {
            _conversationUI.SetActive(true);
        }

        private void UpdateUI(Sprite characterSprite, string characterName, string characterMessage)
        {
            _conversationImage.sprite = characterSprite;
            _conversationSpeaker.text = characterName;
            _conversationSpeechText.text = characterMessage;

            // Increment the counter by one to progress the conversation
            if (_conversationCount <= _conversation.Dialog.Length)
            {
                _conversationCount++;
            }
            else
            {
                _conversationCount = 0;
                ResetUI();
            }
        }

        private void ResetUI()
        {
            _conversationUI.SetActive(false);
            _conversationImage.sprite = null;
            _conversationSpeaker.text = null;
            _conversationSpeechText.text = null;
        }
    }
}
