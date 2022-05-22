using System.IO;
using UnityEngine;

namespace ImageToSprite
{
    public class ImageToSprite
    {
        private static Sprite _createdSprite;

        public static Sprite SpriteFromFile(string path)
        {
            if (path != null)
            {
                byte[] spritebyte = File.ReadAllBytes(path);
                if (spritebyte != null) // Making sure the Bytes are there then proceeding 
                {
                    Texture2D texture = new Texture2D(512, 512);
                    if (Il2CppImageConversionManager.LoadImage(texture, spritebyte)) //Making sure that it can be loaded then continuing
                    {
                        Sprite sprite = Sprite.CreateSprite(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f, 0, 0, new Vector4(), false);
                        sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset; // Making sure The object will not be unloaded by Resources.UnloadUnusedAssets.
                        _createdSprite = sprite;
                    }
                }
            }
            return _createdSprite;
            /*
            If you want to download an image to use it as a sprite, the proper way to do it would be to use webclient to download the image permanently instead of every call

            This will help users with limited bandwidth as restarting your game over and over can cause a bigger build up it may look small but small things add up.
            If you don't know how to create a webClient to Download an image I will show you.

            WebClient webClient = new WebClient(); // WebClient uses Internet Explorer so make sure the site can be loaded there first.
            webClient.Proxy = null;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:99.0) Gecko/20100101 Firefox/99.0");
            string url = "URL-Here";  // Change the URL to an http so it can be accessed. Some Don't require but out of experience most do. 
            string fileName = "FileName-Here";
            webClient.DownloadFile(new Uri(url), fileName);

            Though the only way I've noticed to get it to work with VRChat is to have a loader because VRChat doesn't like it and you usually get the error of Target Machine Actively Refused it.
            But Through Console Applications the same link and code will work fine. 
            */
        }
    }
}
