using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;

namespace Chip8
{
    partial class FScreen : Form
    {
        const int SCALE = 3;

        public static readonly Dictionary<Keys, int> DEFAULT_KEYS = new Dictionary<Keys, int> {
            { Keys.D1, 0x1 }, { Keys.D2, 0x2 }, { Keys.D3, 0x3 }, { Keys.D4, 0xc },
            { Keys.Q, 0x4 },  { Keys.W, 0x5 },  { Keys.E, 0x6 },  { Keys.R, 0xd },
            { Keys.A, 0x7 },  { Keys.S, 0x8 },  { Keys.D, 0x9 },  { Keys.F, 0xe },
            { Keys.Z, 0xa },  { Keys.X, 0x0 },  { Keys.C, 0xb },  { Keys.V, 0xf },
        };

        CPU _cpu;
        Bitmap _buffer;

        int _drawCount = 0;
        Thread _drawThread;

        public Dictionary<Keys, int> KeyMapping { get; set;  }

        public FScreen (CPU cpu)
        {
            BackColor = Color.Black;

            _cpu = cpu;
            KeyMapping = DEFAULT_KEYS;
            
            _buffer = new Bitmap (_cpu.VideoWidth, _cpu.VideoHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage (_buffer))
                g.FillRectangle (new SolidBrush (Color.Black), 0, 0, _buffer.Width, _buffer.Height);

            KeyDown += FScreen_KeyDown;
            KeyUp += FScreen_KeyUp;

            InitializeComponent ();

            _drawThread = new Thread (() => {
                byte[] video = new byte[_cpu.Video.Length];

                while (!IsDisposed)
                {
                    if (_drawCount > 0)
                    {
                        Interlocked.Decrement (ref _drawCount);

                        Array.Copy (_cpu.Video, video, video.Length);
                        RedrawInternal (video);
                    }

                    Thread.Yield ();
                }
            });

            _drawThread.Priority = ThreadPriority.Highest;
            _drawThread.IsBackground = false;
            _drawThread.Start ();
        }

        int GetPressedKeyIndex (Keys key)
        {
            int result;
            if (KeyMapping.TryGetValue (key, out result))
                return result;

            return -1;
        }

        void FScreen_KeyUp (object sender, KeyEventArgs e)
        {
            int index = GetPressedKeyIndex (e.KeyCode);
            if (index != -1)
                _cpu.SetInput (index, false);
        }

        void FScreen_KeyDown (object sender, KeyEventArgs e)
        {
            int index = GetPressedKeyIndex (e.KeyCode);
            if (index != -1)
                _cpu.SetInput (index, true);
        }

        public void Redraw ()
        {
            Interlocked.Increment (ref _drawCount);
        }

        void RedrawInternal (byte[] video)
        {
            int w = _cpu.VideoWidth;
            int h = _cpu.VideoHeight;

#if USE_POINTERS
            BitmapData data = _buffer.LockBits (new Rectangle (0, 0, w, h), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            int voffset = 0;

            unsafe
            {
                fixed (byte* vptr = &(video[0]))
                {
                    byte* ptr = (byte*) data.Scan0;

                    for (int j = 0; j < h; j++)
                    {
                        byte* px = ptr + 1;

                        for (int i = 0; i < w; i++)
                        {
                            *px = (byte) (vptr[voffset++] * 255);
                            px += 4;
                        }

                        ptr += data.Stride;
                    }
                }
            }
            _buffer.UnlockBits (data);

#else
            using (Graphics g = Graphics.FromImage (_buffer))
            {
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

                using (Brush b = new SolidBrush (Color.Black))
                    g.FillRectangle (b, 0, 0, w, h);

                Brush bw = new SolidBrush (Color.White);

                for (int y = 0; y < h; ++y)
                {
                    for (int x = 0; x < w; ++x)
                    {
                        if (video[(y * w) + x] == 0)
                            continue;

                        g.FillRectangle (bw, x, y, 1, 1);
                    }
                }

                bw.Dispose ();
            }
#endif

            using (Graphics g = CreateGraphics ())
            {
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

                g.DrawImage (_buffer, 0, 0, ClientSize.Width, ClientSize.Height);
            }
        }

        private void InitializeComponent ()
        {
            this.SuspendLayout();

            this.ClientSize = new System.Drawing.Size(CPU.VIDEO_WIDTH * SCALE, CPU.VIDEO_HEIGHT * SCALE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FScreen";
            this.Text = "Video output";

            this.ResumeLayout(false);
        }
    }
}
