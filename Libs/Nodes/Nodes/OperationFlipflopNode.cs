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
    public class OperationFlipflopNode : Node
    {
        private int part = 0;
        string result = null;

        /// <summary>
        /// Flip-Flop (1 input, 1 output).
        /// </summary>
        public OperationFlipflopNode() : base(1, 1)
        {
            this.Title = "Flip-Flop";
            this.Type = "Operation/Flip-Flop";

        }

        public override void Loop()
        {
        }

        public override void OnInputChange(Input input)
        {
            if (Inputs[0].Value == null)
            {
                LogInfo($"Operation/Flip-Flop: [NULL]");
                Outputs[0].Value = null;
            }
            else if (Inputs[0].Value == "1" || Inputs[0].Value == "0")
            {
                switch (part)
                {
                    case 0:
                        if (Inputs[0].Value == "1")
                        {
                            result = "1";
                            part++;
                        }
                        break;

                    case 1:
                        if (Inputs[0].Value == "0")
                        {
                            result = "1";
                            part++;
                        }
                        break;

                    case 2:
                        if (Inputs[0].Value == "1")
                        {
                            result = "0";
                            part++;
                        }
                        break;

                    case 3:
                        if (Inputs[0].Value == "0")
                        {
                            result = "0";
                            part = 0;
                        }
                        break;
                }

                LogInfo($"Operation/Flip-Flop: [{Inputs[0].Value}] Flip-Flop to [{result}]");
                Outputs[0].Value = result;
            }
            else
            {
                LogError($"Operation/Flip-Flop: Incorrect value in input");
                Outputs[0].Value = null;
            }
        }
    }
}