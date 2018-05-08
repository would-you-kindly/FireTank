using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public class GameObject
    {
        public string name = string.Empty;
        public string type = string.Empty;
        public float rotation = 0.0f;
        public FloatRect rect = new FloatRect();
        public Dictionary<string, string> properties = new Dictionary<string, string>();
        public Sprite sprite = new Sprite();

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
