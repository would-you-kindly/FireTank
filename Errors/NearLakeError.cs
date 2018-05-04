﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public class NearLakeError : Error
    {
        public NearLakeError()
        : base()
        {
            message += $"Нельзя пополнять запасы воды, не находясь рядом с озером.";
        }

        public override string ToString()
        {
            return message;
        }
    }
}
