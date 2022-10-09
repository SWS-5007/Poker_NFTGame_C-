using UnityEngine;
using System.Collections;
using System;
using System.IO;

namespace BLabTexasHoldEmProject
{
    public class BBStaticVariable
    {
#if USE_PHOTON
#region multiplayerTmpData
        public static CloudRegionCode selectedRegionCode = CloudRegionCode.eu;
        public static string currentMPPlayerName = "";
        public static string currentMPRoomName = "";
        public static int currentMPmaxPlayerNumber = 2;
        public const string photonConnectionVersion = "9.1";
#endregion
#endif

        public static string myAvatarImageNameIdx = "0";

        public const int secondsWaitToStartNewGameHand = 30;
        public const int atBetRequestResponseTimeOutSeconds = 15;

        public const float gameLimitedStackValue = 1000;

        public const float baseStartingMoneyForPlayer = 10000;

        public static BBGlobalDefinitions.GameType gameType;

        public static float updatePlayerGeneralMoney(bool addMoney, float value)
        {
            float tmpValue = PlayerPrefs.GetFloat("MPGeneralPlayerMoney");
            if (addMoney)
            {
                tmpValue += value;
            }
            else
            {
                tmpValue -= value;
            }
            PlayerPrefs.SetFloat("MPGeneralPlayerMoney", tmpValue);
            return tmpValue;
        }

        public static string getStringByteFromTexture(Texture2D tex)
        {
            byte[] byteArray = tex.EncodeToPNG();
            string camImageBytes = Convert.ToBase64String(byteArray);
            return camImageBytes;
        }

        public static Sprite getSpriteFromBytes(
            string bArray,
            bool getFromByteArray,
            string avatarIdx
        )
        {
            Sprite tmpSprite = null;

            if (getFromByteArray)
            {
                Texture2D text = new Texture2D(1, 1, TextureFormat.ARGB32, false);
                text.LoadImage(Convert.FromBase64String(bArray));
                tmpSprite = Sprite.Create(
                    text,
                    new Rect(0, 0, text.width, text.height),
                    new Vector2(.5f, .5f)
                );
            }
            else
            {
                tmpSprite = Resources.Load<Sprite>("Avatar/playerAvatar_" + avatarIdx);
            }

            return tmpSprite;
        }

        public static Texture2D LoadPNG(string filePath)
        {
            Texture2D tex = null;
            byte[] fileData;

            if (File.Exists(filePath))
            {
                fileData = File.ReadAllBytes(filePath);
                tex = new Texture2D(2, 2);
                tex.LoadImage(fileData);
            }
            return tex;
        }
    }
}
