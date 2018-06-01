using System;
using SFML.Graphics;
using SFML.System;

namespace FireSafety
{
    public class Wind : Entity
    {
        // Направление ветра
        public enum Direction
        {
            Up,
            UpLeft,
            Left,
            LeftDown,
            Down,
            DownRight,
            Right,
            RightUp
        }

        private Text powerText;
        private Text timeText;

        public Direction direction;
        public int power;
        public int time;
        public int currentCycle;
        private int cycles;

        private string[] settings;

        // Инициализирует объект Wind, устанавливает направление ветра в Direction.Up
        public Wind(Direction direction = Direction.Up)
        {
            this.direction = direction;
        }

        public Wind(Textures.ID id, ResourceHolder resources, string parameters)
            : base(id, resources)
        {
            settings = parameters.Split();
            currentCycle = 0;
            cycles = settings.Length / 3;

            direction = ParseDirection(settings[currentCycle * 3 + 0]);
            power = int.Parse(settings[currentCycle * 3 + 1]);
            time = int.Parse(settings[currentCycle * 3 + 2]);

            // Устанавливаем параметры ветра для отображения на карте
            Utilities.CenterOrigin(sprite);
            sprite.Position = new Vector2f(Utilities.GetInstance().TILE_SIZE * Utilities.GetInstance().WIDTH_TILE_COUNT - Utilities.GetInstance().TILE_SIZE * 1.0f,
                Utilities.GetInstance().TILE_SIZE * Utilities.GetInstance().HEIGHT_TILE_COUNT - Utilities.GetInstance().TILE_SIZE * 0.5f);
            SetRotation();

            powerText = new Text(power.ToString(), resources.GetFont(Fonts.ID.Sansation), 20);
            powerText.Position = new Vector2f(Utilities.GetInstance().TILE_SIZE * Utilities.GetInstance().WIDTH_TILE_COUNT - Utilities.GetInstance().TILE_SIZE * 1.75f,
                Utilities.GetInstance().TILE_SIZE * Utilities.GetInstance().HEIGHT_TILE_COUNT - Utilities.GetInstance().TILE_SIZE * 0.5f);
            powerText.FillColor = Color.Blue;
            powerText.OutlineThickness = 0.25f;
            Utilities.CenterOrigin(powerText);

            timeText = new Text(time.ToString(), resources.GetFont(Fonts.ID.Sansation), 20);
            timeText.Position = new Vector2f(Utilities.GetInstance().TILE_SIZE * Utilities.GetInstance().WIDTH_TILE_COUNT - Utilities.GetInstance().TILE_SIZE * 0.25f,
                Utilities.GetInstance().TILE_SIZE * Utilities.GetInstance().HEIGHT_TILE_COUNT - Utilities.GetInstance().TILE_SIZE * 0.5f);
            timeText.FillColor = Color.Blue;
            timeText.OutlineThickness = 0.25f;
            Utilities.CenterOrigin(timeText);
        }

        private void ChangeDirection(Direction direction)
        {
            this.direction = direction;
        }

        private void ChangeDirection()
        {
            time--;

            if (time == 0)
            {
                currentCycle = (currentCycle + 1) % cycles;

                direction = ParseDirection(settings[currentCycle * 3 + 0]);
                power = int.Parse(settings[currentCycle * 3 + 1]);
                time = int.Parse(settings[currentCycle * 3 + 2]);
            }
        }

        private Direction ParseDirection(string direction)
        {
            switch (direction)
            {
                case "up":
                    return Direction.Up;
                case "upleft":
                    return Direction.UpLeft;
                case "left":
                    return Direction.Left;
                case "leftdown":
                    return Direction.LeftDown;
                case "down":
                    return Direction.Down;
                case "downright":
                    return Direction.DownRight;
                case "right":
                    return Direction.Right;
                case "rightup":
                    return Direction.RightUp;
                default:
                    throw new Exception("Неверно указано направление ветра. Проверьте правильность значений переменных карты.");
            }
        }

        public override string ToString()
        {
            string result = string.Empty;

            for (int i = 0; i < cycles; i++)
            {
                result += "(";
                switch (ParseDirection(settings[i * 3 + 0]))
                {
                    case Direction.Up:
                        result += Properties.Resources.WindUp;
                        break;
                    case Direction.UpLeft:
                        result += Properties.Resources.WindUpLeft;
                        break;
                    case Direction.Left:
                        result += Properties.Resources.WindLeft;
                        break;
                    case Direction.LeftDown:
                        result += Properties.Resources.WindLeftDown;
                        break;
                    case Direction.Down:
                        result += Properties.Resources.WindDown;
                        break;
                    case Direction.DownRight:
                        result += Properties.Resources.WindDownRight;
                        break;
                    case Direction.Right:
                        result += Properties.Resources.WindRight;
                        break;
                    case Direction.RightUp:
                        result += Properties.Resources.WindRightUp;
                        break;
                }

                result += ", Сила: " + settings[i * 3 + 1];
                result += ", Прод-ть: " + settings[i * 3 + 2] + "); ";
            }

            return result;
        }

        public override void Update(Time deltaTime)
        {
            ChangeDirection();

            SetRotation();

            powerText.DisplayedString = power.ToString();
            timeText.DisplayedString = time.ToString();
        }

        private void SetRotation()
        {
            switch (direction)
            {
                case Direction.Up:
                    sprite.Rotation = 360.0f - 0.0f;
                    break;
                case Direction.UpLeft:
                    sprite.Rotation = 360.0f - 45.0f;
                    break;
                case Direction.Left:
                    sprite.Rotation = 360.0f - 90.0f;
                    break;
                case Direction.LeftDown:
                    sprite.Rotation = 360.0f - 135.0f;
                    break;
                case Direction.Down:
                    sprite.Rotation = 360.0f - 180.0f;
                    break;
                case Direction.DownRight:
                    sprite.Rotation = 360.0f - 225.0f;
                    break;
                case Direction.Right:
                    sprite.Rotation = 360.0f - 270.0f;
                    break;
                case Direction.RightUp:
                    sprite.Rotation = 360.0f - 315.0f;
                    break;
                default:
                    break;
            }
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(sprite, states);
            target.Draw(powerText, states);
            target.Draw(timeText, states);
        }
    }
}
