﻿//planer-pro copyright 2015 GPL - license.

namespace MyNetSensors.Nodes
{
    public class LogicCompareEqualNode : Node
    {
        public LogicCompareEqualNode() : base("Logic", "Compare Equal")
        {
            AddInput();
            AddInput();
            AddOutput(DataType.Logical);

            options.ResetOutputsIfAnyInputIsNull = true;
        }

        public override void OnInputChange(Input input)
        {
            try
            {
                var a = double.Parse(Inputs[0].Value);
                var b = double.Parse(Inputs[1].Value);

                Outputs[0].Value = a == b ? "1" : "0";
            }
            catch
            {
                Outputs[0].Value = Inputs[0].Value == Inputs[1].Value ? "1" : "0";
            }
        }

        public override string GetNodeDescription()
        {
            return "This node compares two values and sends \"1\" to the output " +
                   "if the values are equal, or \"0\" if not equal. \n" +
                   "It can compare text or numbers. \n" +
                   "For example, the node will assume that \"1\" and \"1.0\" are equal. \n" +
                   "\"Hello\" and \"HELLO\" are not equal. ";
        }
    }
}