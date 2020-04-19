using System;
using System.Collections.Generic;

namespace Chip8
{
    static class Disassembler
    {
        static int GetOperand (int opcode, int mask)
        {
            int result = opcode & mask;

            if ((mask & 0x000f) != 0)
                return result;
            else if ((mask & 0x00f0) != 0)
                return result >> 4;
            else if ((mask & 0x0f00) != 0)
                return result >> 8;
            else if ((mask & 0xf000) != 0)
                return result >> 12;

            return result;
        }

        public static string Disassemble (int opcode)
        {
            int type = (opcode & 0xf000) >> 12;
            Dictionary<string, int[]> table;

            if (type == 0)
            {
                table = TABLE_0x0000;
                type = opcode & 0x00ff;
            }
            else if (type == 8)
            {
                table = TABLE_0x8000;
                type = opcode & 0x000f;
            }
            else if (type == 0xf)
            {
                table = TABLE_0xf000;
                type = opcode & 0x00ff;
            }
            else
            {
                table = TABLE_GENERIC;
            }

            foreach (var kv in table)
            {
                int[] op = kv.Value;
                if (op[0] != type)
                    continue;

                string mnemonic = kv.Key;
                if (op.Length == 1)
                    return mnemonic;

                string format = OPERAND_FORMAT[mnemonic];
                string args;

                switch (op.Length)
                {
                    case 2:
                        args = string.Format (format, GetOperand (opcode, op[1]));
                        break;

                    case 3:
                        args = string.Format (format, GetOperand (opcode, op[1]), GetOperand (opcode, op[2]));
                        break;
                    
                    case 4:
                        args = string.Format (format, GetOperand (opcode, op[1]), GetOperand (opcode, op[2]), GetOperand (opcode, op[3]));
                        break;

                    default:
                        args = "<unknown>";
                        break;
                }

                return mnemonic + "\t" + args;
            }

            return "---";
        }


        static readonly Dictionary<string, int[]> TABLE_GENERIC = new Dictionary<string, int[]> {
            { "jump", new int[] { 0x1, 0x0fff } },
            { "call", new int[] { 0x2, 0x0fff } },
            { "ske", new int[] { 0x3, 0x0f00, 0x00ff } },
            { "skne", new int[] { 0x4, 0x0f00, 0x00ff } },
            { "skre", new int[] { 0x5, 0x0f00, 0x00f0 } },
            { "load", new int[] { 0x6, 0x0f00, 0x00ff } },
            { "add", new int[] { 0x7, 0x0f00, 0x00ff } },
            { "skrne", new int[] { 0x9, 0x0f00, 0x00f0 } },
            { "loadi", new int[] { 0xa, 0x0fff } },
            { "jumpi", new int[] { 0xb, 0x0fff } },
            { "rand", new int[] { 0xc, 0x0f00, 0x00ff } },
            { "draw", new int[] { 0xd, 0x0f00, 0x00f0, 0x000f } },
        };

        static readonly Dictionary<string, int[]> TABLE_0x0000 = new Dictionary<string, int[]> {
            { "clr", new int[] { 0xe0 } },
            { "rts", new int[] { 0xee } },
        };

        static readonly Dictionary<string, int[]> TABLE_0x8000 = new Dictionary<string, int[]> {
            { "move", new int[] { 0x0, 0x0f00, 0x00f0 } },
            { "or", new int[] { 0x1, 0x0f00, 0x00f0 } },
            { "and", new int[] { 0x2, 0x0f00, 0x00f0 } },
            { "xor", new int[] { 0x3, 0x0f00, 0x00f0 } },
            { "addr", new int[] { 0x4, 0x0f00, 0x00f0 } },
            { "sub", new int[] { 0x5, 0x0f00, 0x00f0 } },
            { "shr", new int[] { 0x6, 0x0f00 } },
            { "shl", new int[] { 0x7, 0x0f00 } },
        };

        static readonly Dictionary<string, int[]> TABLE_0xf000 = new Dictionary<string, int[]> {
            { "moved", new int[] { 0x07, 0x0f00 } },
            { "keyd", new int[] { 0x0a, 0x0f00 } },
            { "loadd", new int[] { 0x15, 0x0f00 } },
            { "loads", new int[] { 0x18, 0x0f00 } },
            { "addi", new int[] { 0x1e, 0x0f00 } },
            { "ldspr", new int[] { 0x29, 0x0f00 } },
            { "bcd", new int[] { 0x33, 0x0f00 } },
            { "stor", new int[] { 0x55, 0x0f00 } },
            { "read", new int[] { 0x65, 0x0f00 } },
        };

        static readonly Dictionary<string, string> OPERAND_FORMAT = new Dictionary<string, string> {
            { "jump", "0x{0:x3}" },
            { "call", "0x{0:x3}" },
            { "ske", "V{0:X}, 0x{1:x2}" },
            { "skne", "V{0:X}, 0x{1:x2}" },
            { "skre", "V{0:X}, V{1:X}" },
            { "load", "V{0:X}, 0x{1:x2}" },
            { "add", "V{0:X}, 0x{1:x2}" },
            { "skrne", "V{0:X}, V{1:X}" },
            { "loadi", "0x{0:x3}" },
            { "jumpi", "0x{0:x3}" },
            { "rand", "V{0:X}, 0x{1:x2}" },
            { "draw", "V{0:X}, V{1:X}, 0x{2:x}" },
            { "move", "V{0:X}, V{1:X}" },
            { "or", "V{0:X}, V{1:X}" },
            { "and", "V{0:X}, V{1:X}" },
            { "xor", "V{0:X}, V{1:X}" },
            { "addr", "V{0:X}, V{1:X}" },
            { "sub", "V{0:X}, V{1:X}" },
            { "shr", "V{0:X}" },
            { "shl", "V{0:X}" },
            { "moved", "V{0:X}" },
            { "keyd", "V{0:X}" },
            { "loadd", "V{0:X}" },
            { "loads", "V{0:X}" },
            { "addi", "V{0:X}" },
            { "ldspr", "V{0:X}" },
            { "bcd", "V{0:X}" },
            { "stor", "V{0:X}" },
            { "read", "V{0:X}" },
        };
    }
}
