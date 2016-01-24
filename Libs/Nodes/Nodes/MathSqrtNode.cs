﻿/*  MyNetSensors 
    Copyright (C) 2015 Derwish <derwish.pro@gmail.com>
    License: http://www.gnu.org/licenses/gpl-3.0.txt  
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNetSensors.Nodes
{
    public class MathSqrtNode : Node
    {
        /// <summary>
        /// Math Sqrt (1 inputs, 1 output).
        /// </summary>
        public MathSqrtNode() : base(1, 1)
        {
            this.Title = "Math Sqrt";
            this.Type = "Math/Sqrt";
        }

        public override void Loop()
        {
            //  Console.WriteLine( $"MATH LOOP {DateTime.Now} {Inputs[0].Value} {Inputs[1].Value}  {Outputs[0].Value}");
        }

        public override void OnInputChange(Input input)
        {
            try
            {
                if (Inputs[0].Value == null)
                {
                    LogInfo($"Math/Sqrt: [NULL]");
                    Outputs[0].Value = null;
                }
                else
                {
                    Double a = Double.Parse(Inputs[0].Value);
                    Double b = Math.Sqrt(a);

                    LogInfo($"Math/Sqrt: sqrt [{a}] = [{b}]");
                    Outputs[0].Value = b.ToString();
                }
            }
            catch
            {
                LogError($"Math/Sqrt: Incorrect value in input");
                Outputs[0].Value = null;
            }
        }
    }
}
