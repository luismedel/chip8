using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8
{
    class CPU
    {
        const double MS_60HZ = 1000 / 60;

        public const int VIDEO_WIDTH = 64;
        public const int VIDEO_HEIGHT = 32;

        /// <summary>
        /// Vx registers
        /// </summary>
        public byte[] V { get; private set; }

        /// <summary>
        /// Addr register
        /// </summary>
        public int I { get; set; }

        public bool[] Input { get; set; }      // input buffer

        public int PC { get; set; }            // program counter
        public int DT { get; set; }            // delay timer
        public int ST { get; set; }            // sound timer

        public int[] CallStack { get; set; }   // call stack
        public int SP { get; set; }            // stack pointer

        public int VideoWidth { get { return VIDEO_WIDTH; } }
        public int VideoHeight { get { return VIDEO_HEIGHT; } }

        public bool VideoUpdated
        {
            get
            {
                bool result = _videoUpdated;
                _videoUpdated = false;
                return result;
            }
        }

        public bool MemoryUpdated
        {
            get
            {
                bool result = _memoryUpdated;
                _memoryUpdated = false;
                return result;
            }
        }

        public bool RegistersUpdated
        {
            get
            {
                bool result = _registersUpdated;
                _registersUpdated = false;
                return result;
            }
        }

        public byte[] Video { get { return _video; } }
        public byte[] Mem { get { return _mem; } }

        public CPU ()
        { }

        public void Load (byte[] program)
        {
            Reset ();
            Array.Copy (program, 0, _mem, 512, program.Length);
        }

        public void Reset ()
        {
            _mem = new byte[4096];
            Array.Copy (FONT, 0, _mem, 0, FONT.Length);

            _video = new byte[VIDEO_WIDTH * VIDEO_HEIGHT];
            V = new byte[16];
            I = 0;
            DT = 0;
            ST = 0;

            PC = 0x200;

            CallStack = new int[16];
            SP = 0;

            Input = new bool[16];

            _lastTime = DateTime.Now;
            _timeDelta = 0;
            _videoUpdated = true;
            _memoryUpdated = true;
            _registersUpdated = true;
        }

        public void SetInput (int keyIndex, bool pressed)
        {
            Input[keyIndex] = pressed;
        }

        public void FetchAndDecode ()
        {
            DateTime current = DateTime.Now;
            _timeDelta += (current - _lastTime).TotalMilliseconds;
            _lastTime = current;

            if (_timeDelta >= MS_60HZ)
            {
                if (DT > 0)
                    DT--;

                if (ST > 0)
                {
                    // no sound :)
                    ST--;
                }

                _timeDelta -= MS_60HZ;
            }

            int op = (_mem[PC++] << 8) | _mem[PC++];

            switch ((op & 0xf000) >> 12)
            {
                case 0:
                    // 00E0 Clears the screen. 
                    if (op == 0x00e0)
                    {
                        int size = VideoWidth * VideoHeight;
                        for (int i = 0; i < size; i++)
                            _video[i] = 0;
                        _videoUpdated = true;
                    }

                    // 00EE Returns from a subroutine.
                    else if (op == 0x00ee)
                    {
                        PC = CallStack[--SP];
                    }

                    // 0NNN Calls RCA 1802 program at address NNN. 
                    else
                    {

                    }
                    break;

                // 1NNN Jumps to address NNN. 
                case 1:
                    PC = op & 0x0fff;
                    break;

                //2NNN Calls subroutine at NNN. 
                case 2:
                    {
                        CallStack[SP++] = PC;
                        PC = op & 0x0fff;
                        break;
                    }

                // 3XNN Skips the next instruction if VX equals NN. 
                case 3:
                    {
                        int reg = (op & 0x0f00) >> 8;
                        if (V[reg] == (op & 0x00ff))
                            PC += 2;
                        break;
                    }

                // 4XNN Skips the next instruction if VX doesn't equal NN. 
                case 4:
                    {
                        int reg = (op & 0x0f00) >> 8;
                        if (V[reg] != (op & 0x00ff))
                            PC += 2;
                        break;
                    }

                // 5XY0 Skips the next instruction if VX equals VY. 
                case 5:
                    {
                        int reg1 = (op & 0x0f00) >> 8;
                        int reg2 = (op & 0x00f0) >> 4;
                        if (V[reg1] == V[reg2])
                            PC += 2;
                        break;
                    }

                // 6XNN Sets VX to NN. 
                case 6:
                    {
                        int reg = (op & 0x0f00) >> 8;
                        V[reg] = (byte) (op & 0x00ff);
                        _registersUpdated = true;
                        break;
                    }

                // 7XNN Adds NN to VX. 
                case 7:
                    {
                        int reg = (op & 0x0f00) >> 8;
                        int v = op & 0x00ff;
                        V[reg] += (byte) (v & 0x00ff);
                        _registersUpdated = true;
                        break;
                    }

                case 8:
                    {
                        int reg1 = (op & 0x0f00) >> 8;
                        int reg2 = (op & 0x00f0) >> 4;

                        switch (op & 0x000f)
                        {
                            // 8XY0 Sets VX to the value of VY. 
                            case 0:
                                V[reg1] = V[reg2];
                                _registersUpdated = true;
                                break;

                            // 8XY1 Sets VX to VX or VY. 
                            case 1:
                                V[reg1] |= V[reg2];
                                _registersUpdated = true;
                                break;

                            // 8XY2 Sets VX to VX and VY. 
                            case 2:
                                V[reg1] &= V[reg2];
                                _registersUpdated = true;
                                break;

                            // 8XY3 Sets VX to VX xor VY. 
                            case 3:
                                V[reg1] ^= V[reg2];
                                _registersUpdated = true;
                                break;

                            // 8XY4 Adds VY to VX. VF is set to 1 when there's
                            // a carry, and to 0 when there isn't. 
                            case 4:
                                {
                                    int r1 = V[reg1];
                                    int r2 = V[reg2];
                                    int sum = r1 + r2;

                                    V[0x0f] = (byte) ((sum > 255) ? 1 : 0);
                                    V[reg1] = (byte) (sum & 0x00ff);
                                    _registersUpdated = true;
                                    break;
                                }

                            // 8XY5 VY is subtracted from VX. VF is set to 0
                            // when there's a borrow, and 1 when there isn't. 
                            case 5:
                                {
                                    int r1 = V[reg1];
                                    int r2 = V[reg2];
                                    int sub = r1 - r2;

                                    V[0x0f] = (byte) ((sub < 0) ? 0 : 1);
                                    V[reg1] = (byte) (sub & 0x00ff);
                                    _registersUpdated = true;
                                    break;
                                }

                            // 8XY6 Shifts VX right by one. VF is set to
                            // the value of the least significant bit of
                            // VX before the shift.
                            case 6:
                                {
                                    V[0x0f] = (byte) (V[reg1] & 0x01);
                                    V[reg1] >>= 1;
                                    _registersUpdated = true;
                                    break;
                                }

                            // 8XY7 Sets VX to VY minus VX. VF is set to 0
                            // when there's a borrow, and 1 when there isn't. 
                            case 7:
                                {
                                    int r1 = V[reg1];
                                    int r2 = V[reg2];
                                    int sub = r2 - r1;

                                    V[0x0f] = (byte) ((sub < 0) ? 0 : 1);
                                    V[reg1] = (byte) (sub & 0x00ff);
                                    _registersUpdated = true;
                                    break;
                                }

                            // 8XYE Shifts VX left by one. VF is set to the
                            // value of the most significant bit of VX before
                            // the shift.
                            case 0x0e:
                                {
                                    V[0x0f] = (byte) (V[reg1] & 0x80);
                                    V[reg1] <<= 1;
                                    _registersUpdated = true;
                                    break;
                                }
                        }
                        break;
                    }

                // 9XY0 Skips the next instruction if VX doesn't equal VY. 
                case 9:
                    {
                        int v1 = V[(op & 0x0f00) >> 8];
                        int v2 = V[(op & 0x00f0) >> 4];
                        if (v1 != v2)
                            PC += 2;
                        break;
                    }

                // ANNN Sets I to the address NNN. 
                case 0x0a:
                    I = op & 0x0fff;
                    break;

                // BNNN Jumps to the address NNN plus V0. 
                case 0x0b:
                    PC = (op & 0x0fff) + V[0];
                    break;

                // CXNN Sets VX to a random number, masked by NN. 
                case 0x0c:
                    {
                        int reg = (op & 0x0f00) >> 8;
                        int mask = op & 0x00ff;
                        V[reg] = (byte) (_rnd.Next () & mask);
                        _registersUpdated = true;
                        break;
                    }

                // DXYN Sprites stored in memory at location in index
                // register (I), maximum 8bits wide. Wraps around the
                // screen. If when drawn, clears a pixel, register VF
                // is set to 1 otherwise it is zero. All drawing is
                // XOR drawing (i.e. it toggles the screen pixels) 
                case 0x0d:
                    {
                        int x = V[(op & 0x0f00) >> 8];
                        int y = V[(op & 0x00f0) >> 4];
                        int n = op & 0x000f;
                        DrawSprite (n, x, y);

                        break;
                    }

                case 0x0e:
                    {
                        int key = V[(op & 0xf00) >> 8];
                        bool pressed = Input[key];
                        switch (op & 0x00ff)
                        {
                            // EX9E Skips the next instruction if the key
                            // stored in VX is pressed. 
                            case 0x9e:
                                PC += pressed ? 2 : 0;
                                break;

                            // EXA1 Skips the next instruction if the key
                            // stored in VX isn't pressed. 
                            case 0xa1:
                                PC += pressed ? 0 : 2;
                                break;
                        }
                        break;
                    }

                case 0x0f:
                    {
                        int reg = (op & 0x0f00) >> 8;

                        switch (op & 0x00ff)
                        {
                            // FX07 Sets VX to the value of the delay timer. 
                            case 0x07:
                                V[reg] = (byte) DT;
                                _registersUpdated = true;
                                break;

                            // FX0A A key press is awaited, and then stored in VX. 
                            case 0x0a:
                                {
                                    int key = GetKeyPress ();
                                    if (key != -1)
                                    {
                                        V[reg] = (byte) key;
                                        _registersUpdated = true;
                                    }
                                    else
                                        PC -= 2;

                                    break;
                                }

                            // FX15 Sets the delay timer to VX. 
                            case 0x15:
                                DT = V[reg];
                                break;

                            // FX18 Sets the sound timer to VX. 
                            case 0x18:
                                ST = V[reg];
                                break;

                            // FX1E Adds VX to I.
                            case 0x1e:
                                {
                                    int sum = I + V[reg];
                                    V[0x0f] = (byte) ((sum > 0x0fff) ? 1 : 0);
                                    I = sum & 0x0fff;
                                    break;
                                }

                            // FX29 Sets I to the location of the sprite
                            // for the character in VX. Characters 0-F
                            // (in hexadecimal) are represented by a 4x5
                            // font. 
                            case 0x29:
                                {
                                    I = V[reg] * 5;
                                    break;
                                }

                            // FX33 Stores the Binary-coded decimal representation
                            // of VX, with the most significant of three digits at
                            // the address in I, the middle digit at I plus 1, and
                            // the least significant digit at I plus 2. (In other
                            // words, take the decimal representation of VX, place
                            // the hundreds digit in memory at location in I, the
                            // tens digit at location I+1, and the ones digit at
                            // location I+2.) 
                            case 0x33:
                                {
                                    int v = V[(op & 0x0f00) >> 8];

                                    _mem[I] = (byte) (v / 100);
                                    _mem[I + 1] = (byte) ((v / 10) % 10);
                                    _mem[I + 2] = (byte) (v % 10);
                                    _memoryUpdated = true;
                                    break;
                                }

                            // FX55 Stores V0 to VX in memory starting at
                            // address I.
                            case 0x55:
                                {
                                    for (int i = 0; i < reg; i++)
                                        _mem[I + i] = V[i];

                                    I += reg + 1;
                                    _memoryUpdated = true;
                                    break;
                                }

                            // FX65 Fills V0 to VX with values from memory
                            // starting at address I.[4] 
                            case 0x65:
                                {
                                    for (int i = 0; i <= reg; i++)
                                        V[i] = _mem[I + i];

                                    I += reg + 1;
                                    _registersUpdated = true;
                                    break;
                                }
                        }
                        break;
                    }
            }
        }

        int GetKeyPress ()
        {
            for (int i = 0; i < Input.Length; i++)
            {
                if (Input[i])
                    return i;
            }

            return -1;
        }

        void DrawSprite (int height, int x, int y)
        {
            V[0x0f] = 0;

            for (int row = 0; row < height; row++)
            {
                int px = _mem[I + row];
                if (px == 0)
                    continue;

                for (int bit = 0; bit < 8; bit++)
                {
                    if ((px & (0x80 >> bit)) == 0)
                        continue;

                    int offset = ((y + row) * VIDEO_WIDTH) + (x + bit);
                    if (offset >= _video.Length)
                        continue;

                    if (_video[offset] == 1)
                    {
                        V[0x0f] = 1;
                        _video[offset] = 0;
                    }
                    else
                        _video[offset] = 1;

                    _videoUpdated = true;
                }
            }
        }

        static readonly byte[] FONT = new byte[80]
        {
            0xF0, 0x90, 0x90, 0x90, 0xF0, //0
			0x20, 0x60, 0x20, 0x20, 0x70, //1
			0xF0, 0x10, 0xF0, 0x80, 0xF0, //2
			0xF0, 0x10, 0xF0, 0x10, 0xF0, //3
			0x90, 0x90, 0xF0, 0x10, 0x10, //4
			0xF0, 0x80, 0xF0, 0x10, 0xF0, //5
			0xF0, 0x80, 0xF0, 0x90, 0xF0, //6
			0xF0, 0x10, 0x20, 0x40, 0x40, //7
			0xF0, 0x90, 0xF0, 0x90, 0xF0, //8
			0xF0, 0x90, 0xF0, 0x10, 0xF0, //9
			0xF0, 0x90, 0xF0, 0x90, 0x90, //A
			0xE0, 0x90, 0xE0, 0x90, 0xE0, //B
			0xF0, 0x80, 0x80, 0x80, 0xF0, //C
			0xE0, 0x90, 0x90, 0x90, 0xE0, //D
			0xF0, 0x80, 0xF0, 0x80, 0xF0, //E
			0xF0, 0x80, 0xF0, 0x80, 0x80  //F
		};

        byte[] _mem;        // main memory
        byte[] _video;      // video memory

        Random _rnd = new Random ();

        DateTime _lastTime;
        double _timeDelta;
        bool _videoUpdated = false;
        bool _memoryUpdated = false;
        bool _registersUpdated = false;
    }
}