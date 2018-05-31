using SFML.Graphics;
using System.Collections.Generic;

namespace FireSafety
{
    public class GameObject
    {
        // Встроенные параметры объекта
        public string name = string.Empty;
        public string type = string.Empty;
        public float rotation = 0.0f;
        public FloatRect rect = new FloatRect();
        public Sprite sprite = new Sprite();
        // Пользовательские параметры объекта
        public Dictionary<string, string> properties = new Dictionary<string, string>();

        public int GetPropertyInt(string name)
        {
            return int.Parse(properties[name]);
        }

        public float GetPropertyFloat(string name)
        {
            return float.Parse(properties[name]);
        }

        public string GetPropertyString(string name)
        {
            return properties[name];
        }

        public bool GetPropertyBool(string name)
        {
            return bool.Parse(properties[name]);
        }
    }
}
