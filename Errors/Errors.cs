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