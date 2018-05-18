using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml;

namespace FireSafety
{
    public class Map : Drawable
    {
        public int width, height, tileWidth, tileHeight;
        private int firstTileID;
        private Texture tilesetImage;
        private List<GameObject> objects = new List<GameObject>();
        private List<Layer> layers = new List<Layer>();
        public Dictionary<string, string> properties = new Dictionary<string, string>();

        public bool LoadFromDatabase(Guid id)
        {
            // Открываем документ с картой в .xml разметке 
            XmlDocument xDoc = new XmlDocument();
            try
            {
                MapModel mapModel = Utilities.GetInstance().context.Maps.Find(id);
                xDoc.LoadXml(mapModel.XmlContent);
                Settings.GetInstance().SetCurrentMap(id);
            }
            catch (Exception)
            {
                Console.WriteLine("Loading level \"" + id.ToString() + "\" failed.");
                return false;
            }

            return Load(xDoc);
        }

        public bool LoadFromFile(string filename)
        {
            // Открываем документ с картой в .xml разметке 
            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.Load(filename);
            }
            catch (Exception)
            {
                Console.WriteLine("Loading level \"" + filename + "\" failed.");
                return false;
            }

            return Load(xDoc);
        }

        private bool Load(XmlDocument xDoc)
        {
            // Получаем информацию о карте (ширину, высоту карты и тайлов)
            XmlElement mapElement = (XmlElement)xDoc.GetElementsByTagName("map")[0];

            // Пример карты: <map version="1.0" orientation="orthogonal"
            // width="10" height="10" tilewidth="34" tileheight="34">
            width = int.Parse(mapElement.GetAttribute("width"));
            height = int.Parse(mapElement.GetAttribute("height"));
            tileWidth = int.Parse(mapElement.GetAttribute("tilewidth"));
            tileHeight = int.Parse(mapElement.GetAttribute("tileheight"));

            // Получаем инфрмацию о свойствах карты
            XmlElement mapPropertiesElement = (XmlElement)mapElement.GetElementsByTagName("properties")[0];
            XmlElement mapPropertyElement = (XmlElement)mapPropertiesElement.GetElementsByTagName("property").Item(0);
            while (mapPropertyElement != null)
            {
                string propertyName = mapPropertyElement.GetAttribute("name");
                string propertyValue = mapPropertyElement.GetAttribute("value");
                properties.Add(propertyName, propertyValue);
                mapPropertyElement = (XmlElement)mapPropertyElement.NextSibling;
            }

            // Получаем информацию о наборе тайлов (firstgid)
            XmlElement tilesetElement = (XmlElement)xDoc.GetElementsByTagName("tileset")[0];
            firstTileID = int.Parse(tilesetElement.GetAttribute("firstgid"));

            // Получаем информацию о картинке (путь к файлу)
            XmlElement imageElement = (XmlElement)xDoc.GetElementsByTagName("image")[0];
            string imagePath = imageElement.GetAttribute("source");

            // Загружаем картинку
            ImageConverter imageConverter = new ImageConverter();
            SFML.Graphics.Image image = new SFML.Graphics.Image((byte[])imageConverter.ConvertTo(Resources.Sprites, typeof(byte[])));
            //Image image = new Image(Path.Combine("Media/", imagePath.Remove(0, 3)));

            // TODO: Проверку добавить
            //if (!img.loadFromFile(imagepath))
            //{
            //    std::cout << "Failed to load tile sheet." << std::endl;
            //    return false;
            //}

            image.CreateMaskFromColor(new SFML.Graphics.Color(255, 255, 255));
            tilesetImage = new Texture(image);
            //tilesetImage.Smooth = false;

            int columns = (int)tilesetImage.Size.X / tileWidth;
            int rows = (int)tilesetImage.Size.Y / tileHeight;

            List<IntRect> subRects = new List<IntRect>();

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    IntRect rect = new IntRect();

                    rect.Top = y * tileHeight;
                    rect.Height = tileHeight;
                    rect.Left = x * tileWidth;
                    rect.Width = tileWidth;

                    subRects.Add(rect);
                }
            }



            // Работа со слоями
            XmlElement layerElement = (XmlElement)xDoc.GetElementsByTagName("layer")[0];

            for (int i = 0; i < xDoc.GetElementsByTagName("layer").Count; i++)
            {
                Layer layer = new Layer();

                if (layerElement.HasAttribute("opacity"))
                {
                    float opacity = float.Parse(layerElement.GetAttribute("opacity"));
                    layer.opacity = (int)(255 * opacity);
                }
                else
                {
                    layer.opacity = 255;
                }

                XmlElement layerDataElement = (XmlElement)layerElement.GetElementsByTagName("data")[0];

                if (layerDataElement == null)
                {
                    Console.WriteLine("Bad map. No layer information found.");
                    return false;
                }

                XmlElement tileElement = (XmlElement)layerDataElement.GetElementsByTagName("tile").Item(0);

                if (tileElement == null)
                {
                    Console.WriteLine("Bad map. No tile information found.");
                    return false;
                }

                int x = 0;
                int y = 0;

                while (tileElement != null)
                {
                    int tileGID = int.Parse(tileElement.GetAttribute("gid"));
                    int subRectToUse = tileGID - firstTileID;

                    // Устанавливаем TextureRect каждого тайла
                    if (subRectToUse >= 0)
                    {
                        Sprite sprite = new Sprite();
                        sprite.Texture = tilesetImage;
                        sprite.TextureRect = subRects[subRectToUse];
                        sprite.Position = new Vector2f(x * tileWidth, y * tileHeight);
                        sprite.Color = new SFML.Graphics.Color(255, 255, 255, (byte)layer.opacity);

                        layer.tiles.Add(sprite);
                    }

                    tileElement = (XmlElement)tileElement.NextSibling;

                    x++;
                    if (x >= width)
                    {
                        x = 0;
                        y++;
                        if (y >= height)
                        {
                            y = 0;
                        }
                    }
                }

                layers.Add(layer);

                layerElement = (XmlElement)xDoc.GetElementsByTagName("layer").Item(i + 1);
            }



            // Работа с объектами
            XmlElement objectGroupElement;

            // Если есть слои объектов
            if (xDoc.GetElementsByTagName("objectgroup").Count != 0)
            {
                objectGroupElement = (XmlElement)xDoc.GetElementsByTagName("objectgroup")[0];

                for (int i = 0; i < xDoc.GetElementsByTagName("objectgroup").Count; i++)
                {
                    // Контейнер <object>
                    XmlElement objectElement = (XmlElement)objectGroupElement.GetElementsByTagName("object")[0];

                    for (int j = 0; j < objectGroupElement.GetElementsByTagName("object").Count; j++)
                    {
                        // Получаем все данные - тип, имя, позиция, etc
                        string objectType = string.Empty;
                        if (objectElement.HasAttribute("type"))
                        {
                            objectType = objectElement.GetAttribute("type");
                        }
                        string objectName = string.Empty;
                        if (objectElement.HasAttribute("name"))
                        {
                            objectName = objectElement.GetAttribute("name");
                        }
                        float objectRotation = 0.0f;
                        if (objectElement.HasAttribute("rotation"))
                        {
                            objectRotation = float.Parse(objectElement.GetAttribute("rotation"));
                        }
                        int x = int.Parse(objectElement.GetAttribute("x"));
                        int y = int.Parse(objectElement.GetAttribute("y"));

                        int width, height;

                        Sprite sprite = new Sprite();
                        sprite.Texture = tilesetImage;
                        sprite.TextureRect = new IntRect(0, 0, 0, 0);
                        sprite.Position = new Vector2f(x, y);

                        if (objectElement.HasAttribute("width"))
                        {
                            width = int.Parse(objectElement.GetAttribute("width"));
                            height = int.Parse(objectElement.GetAttribute("height"));
                        }
                        else
                        {
                            width = subRects[int.Parse(objectElement.GetAttribute("gid")) - firstTileID].Width;
                            height = subRects[int.Parse(objectElement.GetAttribute("gid")) - firstTileID].Height;
                            sprite.TextureRect = subRects[int.Parse(objectElement.GetAttribute("gid")) - firstTileID];
                        }

                        // Экземпляр объекта
                        GameObject obj = new GameObject();
                        obj.name = objectName;
                        obj.type = objectType;
                        obj.rotation = objectRotation;
                        obj.sprite = sprite;

                        FloatRect objectRect = new FloatRect();
                        objectRect.Left = x;
                        objectRect.Top = y;
                        objectRect.Width = width;
                        objectRect.Height = height;
                        obj.rect = objectRect;

                        // "Переменные" объекта
                        XmlElement properties = (XmlElement)objectElement.GetElementsByTagName("properties")[0];
                        if (properties != null)
                        {
                            XmlElement prop = (XmlElement)properties.GetElementsByTagName("property")[0];
                            if (prop != null)
                            {
                                for (int k = 0; k < properties.GetElementsByTagName("property").Count; k++)
                                {
                                    string propertyName = prop.GetAttribute("name");
                                    string propertyValue = prop.GetAttribute("value");

                                    obj.properties[propertyName] = propertyValue;

                                    prop = (XmlElement)xDoc.GetElementsByTagName("property").Item(k + 1);
                                }
                            }
                        }


                        objects.Add(obj);

                        objectElement = (XmlElement)objectGroupElement.GetElementsByTagName("object").Item(j + 1);
                    }
                    objectGroupElement = (XmlElement)xDoc.GetElementsByTagName("objectgroup").Item(i + 1);
                }
            }
            else
            {
                Console.WriteLine("No object layers found...");
            }

            return true;
        }

        public GameObject GetObject(string name)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                if (objects[i].name == name)
                {
                    return objects[i];
                }
            }

            throw new Exception("No object found...");
        }

        public List<GameObject> GetObjects(string name)
        {
            List<GameObject> list = new List<GameObject>();

            for (int i = 0; i < objects.Count; i++)
            {
                if (objects[i].name == name)
                {
                    list.Add(objects[i]);
                }
            }

            return list;
        }

        public List<GameObject> GetAllObjects()
        {
            return objects;
        }

        public Vector2i GetTileSize()
        {
            return new Vector2i(tileWidth, tileHeight);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            for (int layer = 0; layer < layers.Count; layer++)
            {
                for (int tile = 0; tile < layers[layer].tiles.Count; tile++)
                {
                    target.Draw(layers[layer].tiles[tile], states);
                }
            }
        }
    }
}