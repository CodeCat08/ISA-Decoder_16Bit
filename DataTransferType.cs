// ------------------------------------------------------------------------------------------------------------------------
// File name:       DataTransferType.cs
// Project name:    ISA
// Project description: Decoder for our awesome Detached-Toe 16-bit RISC ISA.
// ------------------------------------------------------------------------------------------------------------------------
// Creation Date: 03/31/2021
// ------------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_Decoder_16Bit {
    /// <summary>
    /// For our data transfer operaations
    /// </summary>
    class DataTransferType : InstructionType {
        public DataTransferType() {
            base.InstructionTypeID = 0;
            base.opcodeStartBit = 13;
        }
    }
}
