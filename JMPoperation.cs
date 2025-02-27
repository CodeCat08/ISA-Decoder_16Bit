// ------------------------------------------------------------------------------------------------------------------------
// File name:       JMPoperation
// Project name:    ISA
// Project description: Decoder for our awesome Detached-Toe 16-bit RISC ISA.
// ------------------------------------------------------------------------------------------------------------------------
// Creation Date: 03/31/2021
// ------------------------------------------------------------------------------------------------------------------------

namespace ISA_Decoder_16Bit {
    /// <summary>
    /// A one operand operation that jumps to an address: either through register refernece, or directly back/forward.
    /// </summary>
    class JMPoperation: Operation {
        string verb = "Jump";                   // The main verb used for the message

        int operandOneEndBit = 9;               // The end bit of operand one
        int operandOneStartBit = 6;             // The starting bit of operand one
        int operandOneValue;                    // The value of operand one
        string operandOneMeaning;               // The meaning of operand one

        //only two addressing modes, one bit needed
        string addressingModeMeaning;

        int immediateSwitchStartBit = 11;       // The start bit of the immediate switch
        int immediateSwitchEndBit = 11;         // The end bit of the immediate switch
        int immediateSwitchValue;               // The value of the immediate switch

        int immediateOperandStartBit = 0;       // The start bit for our immediate operand (the 2nd operand)

        /// <summary>
        /// Default Construction
        /// </summary>
        public JMPoperation() {
        }

        /// <summary>
        /// Decodes the input bits. This calls all the other functions.
        /// </summary>
        /// <param name="inputBits">a bit stream of the instruction</param>
        /// <returns>a text translation of the instruction</returns>
        public override string DecodeOperation(int inputBits) {
            // Decode Immediate
            DecodeImmediateSwitch(inputBits);

            // Decode Operand One
            DecodeFirstOperand(inputBits);

            // Get readable text
            return GetHumanText();
        }

        /// <summary>
        /// Decode the first operand of this instruction by masking it and 
        /// 1) Determining its value
        /// 2) Assigning it a textual meaning. (FIX THIS)
        /// </summary>
        /// <param name="inputBits">instruction bits</param>
        private void DecodeFirstOperand(int inputBits) {
            operandOneValue = BitUtilities.MaskInput(inputBits, operandOneStartBit, operandOneEndBit);
            if (operandOneValue < 0 || operandOneValue > 15)
            { //used to check if valid register
                operandOneMeaning = $"OP1: Ya messed* up";
            }
            else {
                operandOneMeaning = $"r{operandOneValue}";
            }
        }

        /// <summary>
        /// Decode value of the immediateSwitch
        /// </summary>
        /// <param name="inputBits">our instruction</param>
        private void DecodeImmediateSwitch(int inputBits)
        {
            immediateSwitchValue = BitUtilities.MaskInput(inputBits, immediateSwitchStartBit, immediateSwitchEndBit);
            if (immediateSwitchValue == 0) // if using register, this is an indirect index reference
                addressingModeMeaning = "an Indexed Indirect Register";
            else
                addressingModeMeaning = "a direct increment.";
        }

        /// <summary>
        /// This badboy looks through ALL our available fields and constructs an English sentence.
        /// </summary>
        private string GetHumanText() 
        {
           return $"{verb} to a location using {operandOneMeaning} as {addressingModeMeaning}";
        }

    }
}
