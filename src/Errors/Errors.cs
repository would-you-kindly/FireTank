using System;
using System.Collections.Generic;
using System.Text;

namespace FireSafety
{
    public class Errors
    {
        public List<Error> errors;

        public Errors()
        {
            errors = new List<Error>();
        }

        public void Add(Error error)
        {
            errors.Add(error);
        }

        public int Count()
        {
            return errors.Count;
        }

        public void Clear()
        {
            errors.Clear();
        }

        public bool Check()
        {
            for (int i = 0; i < errors.Count; i++)
            {
                if (errors[i] is CollidedError)
                {
                    // Если танки действительно столкнулись, то не удаляем ошибку
                    if (((CollidedError)errors[i]).CheckTanksCollide() == true)
                    {
                        continue;
                    }
                    // Если танки на РАЗНЫХ координатах и при этом не столкнулись лоб в лоб, то удаляем ошибку
                    else if ((((CollidedError)errors[i]).CheckTanksCollide() == false))
                    {
                        errors.Remove(errors[i]);
                        i--;
                    }
                    else if ((((CollidedError)errors[i]).CheckTanksCollide() == null))
                    {
                        // Столкновение произошло не с танком, значит обрабатываем ошибку
                    }
                }
            }

            return Count() != 0;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            if (errors.Count == 1)
            {
                result.Append("Во время выполнения алгоритма произошла ошибка:\n\n");
            }
            else if (errors.Count > 1)
            {
                result.Append("Во время выполнения алгоритма произошли ошибки:\n\n");
            }

            for (int i = 0; i < errors.Count; i++)
            {
                result.Append($"{i + 1}. {errors[i].ToString()}\n");
            }

            return result.ToString();
        }
    }
}