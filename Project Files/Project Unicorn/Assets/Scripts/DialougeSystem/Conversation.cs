using System;

using UnityEngine;

/**
 * File: Conversation.cs
 * Description: Defines a scriptable object that will hold an entire conversation
 * Author: Bryan Sanchez (Tegomlee)
 * Date: 2024-09-22
 */

namespace ProjectUnicorn.DialogSystem
{
    [CreateAssetMenu(fileName = "Conversation", menuName = "DialogSystem/Conversation")]
    public class Conversation : ScriptableObject
    {
        [Serializable]
        public class Speech
        {
            public Sprite CharacterImage;
            public string CharacterName;
            public string CharacterMessage;
        }

        public Speech[] Dialog;
    }
}
