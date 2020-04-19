using Be.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chip8
{
    partial class FMain : Form
    {
        CPU _cpu;
        HexBox _hexbox;
        Button[] _input;

        FScreen _screen;
        ByteProvider _byteProvider;

        int _deltaSteps = 0;
        bool _running = false;

        public FMain ()
        {
            InitializeComponent ();
            Init ();
        }

        void Init ()
        {
            SuspendLayout ();

            _input = new Button[] {
                btnInput0, btnInput1, btnInput2, btnInput3,
                btnInput4, btnInput5, btnInput6, btnInput7,
                btnInput8, btnInput9, btnInputA, btnInputB,
                btnInputC, btnInputD, btnInputE, btnInputF
            };

            Font = SystemFonts.DialogFont;

            _hexbox = new HexBox { Dock = DockStyle.Fill, Visible = true };
            pnlHex.Controls.Add (_hexbox);

            _hexbox.GroupSeparatorVisible = true;
            _hexbox.GroupSize = 8;
            _hexbox.HexCasing = HexCasing.Upper;
            _hexbox.BytesPerLine = 16;
            _hexbox.ColumnInfoVisible = true;
            _hexbox.LineInfoVisible = true;
            _hexbox.StringViewVisible = true;
            _hexbox.UseFixedBytesPerLine = true;
            _hexbox.VScrollBarVisible = true;

            _hexbox.Font = lstDump.Font = new Font (FontFamily.GenericMonospace, lstDump.Font.Size);

            txtPC.LostFocus += txtPC_LostFocus;
            txtI.LostFocus += txtI_LostFocus;
            txtST.LostFocus += txtST_LostFocus;
            txtDT.LostFocus += txtDT_LostFocus;

            lstDump.Enabled = txtPC.Enabled = txtI.Enabled =
            loadROMToolStripMenuItem.Enabled = runToolStripMenuItem.Enabled =
            stepToolStripMenuItem.Enabled = btnStep.Enabled = btnRun.Enabled =
            btnPause.Enabled = false;

            UpdateUIState ();

            ResumeLayout ();
        }

        void InitEmulation ()
        {
            if (_cpu == null)
                return;

            int instructions = _cpu.Mem.Length / 2;

            lstDump.Items.AddRange (Enumerable.Range (0, instructions)
                                              .Select (i => string.Empty)
                                              .ToArray ());

            for (int i = 0; i < instructions; i += 2)
                DisassembleOffset (i);

            _hexbox.ByteProvider = _byteProvider;
        }

        void DisassembleOffset (int offset)
        {
            int row = (int) (offset / 2);

            int oph = _cpu.Mem[offset];
            int opl = _cpu.Mem[offset + 1];
            int opcode = (oph << 8) | opl;

            lstDump.Items[row] = string.Format ("0x{0:x3}\t", offset) +
                                 string.Format ("{0:x2} {1:x2}\t", oph, opl) +
                                 Disassembler.Disassemble (opcode);
        }

        void Run ()
        {
            if (_running)
                return;

            _running = true;
            UpdateUIState ();

            Action action = () => { Step (false); };

            Thread thread = new Thread (() => {
                while (_running)
                {
                    this.InvokeEx (action);
                    Thread.Yield ();
                }
            });

            thread.Priority = ThreadPriority.Normal;
            thread.IsBackground = false;

            thread.Start ();
        }

        void Step (bool forcePCVisibility)
        {
            _cpu.FetchAndDecode ();
            RefreshState (forcePCVisibility);

            _deltaSteps++;
            if ((_deltaSteps % 100) == 0)
            {
                _deltaSteps = 0;
                Application.DoEvents ();
            }
        }

        void Pause ()
        {
            if (!_running)
                return;

            _running = false;

            UpdateUIState ();
            RefreshState (true);
        }

        void LoadRom (string path)
        {
            _cpu = new CPU ();
            _cpu.Load (System.IO.File.ReadAllBytes (path));
            _byteProvider = new ByteProvider (_cpu.Mem);
            _byteProvider.BytesModified += ByteProvider_BytesModified;

            status.Items["lblROM"].Text = path;

            InitEmulation ();
            RefreshState (true);
        }

        void UpdateUIState ()
        {
            lstDump.Enabled = txtPC.Enabled = txtI.Enabled = loadROMToolStripMenuItem.Enabled =
            runToolStripMenuItem.Enabled = stepToolStripMenuItem.Enabled =
            btnStep.Enabled = btnRun.Enabled = !_running;

            btnPause.Enabled = _running;
        }

        void txtPC_LostFocus (object sender, EventArgs e)
        {
            int value = IntFromHex (txtPC.Text);
            if (value == _cpu.PC)
                return;

            if (value != -1)
            {
                value &= 0x0fff;
                _cpu.PC = value - (value % 2);
            }

            RefreshCpuState (true);
        }

        void txtI_LostFocus (object sender, EventArgs e)
        {
            int value = IntFromHex (txtI.Text);
            if (value == _cpu.I)
                return;

            if (value != -1)
                _cpu.I = value & 0x0fff;

            RefreshCpuState (true);
        }

        void txtDT_LostFocus (object sender, EventArgs e)
        {
            int value = IntFromHex (txtDT.Text);
            if (value == _cpu.DT)
                return;

            if (value != -1)
                _cpu.DT = value & 0x00ff;

            RefreshCpuState (true);
        }

        void txtST_LostFocus (object sender, EventArgs e)
        {
            int value = IntFromHex (txtST.Text);
            if (value == _cpu.ST)
                return;

            if (value != -1)
                _cpu.ST = value & 0x00ff;

            RefreshCpuState (true);
        }

        void RefreshState (bool forcePCVisibility)
        {
            RefreshCpuState (forcePCVisibility);

            if (_cpu.MemoryUpdated)
                RefreshMemory ();

            if (_cpu.RegistersUpdated)
                RefreshRegisters ();

            if (_cpu.VideoUpdated)
                RefreshScreen ();

            RefreshInput ();
        }

        void RefreshMemory ()
        {
            _byteProvider.Refresh ();
            _hexbox.Update ();
        }

        void RefreshRegisters ()
        {
            if (gridRegs.Rows.Count == 0)
            {
                gridRegs.Rows.Add (0xf + 1);

                for (int i = 0; i < gridRegs.Rows.Count; i++)
                    gridRegs.Rows[i].Cells[0].Value = i.ToString ("x");
            }

            for (int i = 0; i < gridRegs.Rows.Count; i++)
                gridRegs.Rows[i].Cells[1].Value = string.Format ("0x{0:x2}", _cpu.V[i]);

            gridRegs.Refresh ();
        }

        void RefreshCpuState (bool forcePCVisibility)
        {
            txtPC.Text = string.Format ("0x{0:x3}", _cpu.PC);
            txtI.Text = string.Format ("0x{0:x3}", _cpu.I);
            txtST.Text = string.Format ("0x{0:x2}", _cpu.ST);
            txtDT.Text = string.Format ("0x{0:x2}", _cpu.DT);
            txtSP.Text = string.Format ("0x{0:x3}", _cpu.SP);

            if (forcePCVisibility)
                lstDump.SelectedIndex = _cpu.PC / 2;
        }

        void RefreshInput ()
        {
            for (int i = 0; i < _cpu.Input.Length; i++)
                _input[i].BackColor = _cpu.Input[i] ? Color.Red : SystemColors.ButtonFace;
        }

        void RefreshScreen ()
        {
            if (_screen == null || _screen.IsDisposed)
                return;

            _screen.Redraw ();
        }

        #region General UI events
        private void Input_MouseDown (object sender, MouseEventArgs e)
        {
            if (_cpu == null)
                return;

            _cpu.Input[Array.IndexOf (_input, sender)] = true;
            RefreshInput ();
        }

        private void Input_MouseUp (object sender, MouseEventArgs e)
        {
            if (_cpu == null)
                return;

            _cpu.Input[Array.IndexOf (_input, sender)] = false;
            RefreshInput ();
        }

        private void lstDump_DoubleClick (object sender, EventArgs e)
        {
            int index = lstDump.SelectedIndex;
            if (index == -1)
                return;

            int b = index * 2;
            _hexbox.ScrollByteIntoView (b);
            _hexbox.Select (b, 2);
        }

        private void btnStep_Click (object sender, EventArgs e)
        {
            Step (true);
        }

        private void btnPause_Click (object sender, EventArgs e)
        {
            Pause ();
        }

        private void btnRun_Click (object sender, EventArgs e)
        {
            Run ();
        }

        private void btnVideo_Click (object sender, EventArgs e)
        {
            if (_cpu == null)
                return;

            if (_screen == null)
            {
                _screen = new FScreen (_cpu);
                _screen.Disposed += Screen_Disposed;

                _screen.Show (this);
            }

            _screen.Activate ();
        }

        private void gridRegs_CellBeginEdit (object sender, DataGridViewCellCancelEventArgs e)
        {
            if (_running)
                e.Cancel = true;
        }

        private void gridRegs_CellEndEdit (object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            try
            {
                string hex = CleanHex (gridRegs.Rows[index].Cells[1].Value.ToString ());
                _cpu.V[index] = Convert.ToByte (hex, 16);
            }
            catch (FormatException)
            { }

            gridRegs.Rows[index].Cells[1].Value = string.Format ("0x{0:x2}", _cpu.V[index]);
        }

        private void FMain_FormClosing (object sender, FormClosingEventArgs e)
        {
            Pause ();
            Application.DoEvents ();
        }
        #endregion

        #region ToolStrip events
        private void stepToolStripMenuItem_Click (object sender, EventArgs e)
        {
            Step (true);
        }

        private void pauseToolStripMenuItem_Click (object sender, EventArgs e)
        {
            Pause ();
        }

        private void runToolStripMenuItem_Click (object sender, EventArgs e)
        {
            Run ();
        }

        private void loadROMToolStripMenuItem_Click (object sender, EventArgs e)
        {
            PromptForRom ();
        }

        private void aboutToolStripMenuItem_Click (object sender, EventArgs e)
        {
            MessageBox.Show ("Chip-8 emulator\nby Luis Medel <luis@luismedel.com>");
        }

        private void exitToolStripMenuItem_Click (object sender, EventArgs e)
        {
            Pause ();
            Close ();
        }
        #endregion

        #region Other component evens
        void ByteProvider_BytesModified (object sender, long offset)
        {
            if (offset % 2 != 0)
                offset--;

            DisassembleOffset ((int) offset);
        }

        void Screen_Disposed (object sender, EventArgs e)
        {
            _screen = null;
        }
        #endregion

        void PromptForRom ()
        {
            using (var fd = new OpenFileDialog ())
            {
                fd.CheckPathExists = true;

                if (fd.ShowDialog () != System.Windows.Forms.DialogResult.OK)
                    return;

                LoadRom (fd.FileName);
            }
        }

        string CleanHex (string value)
        {
            value = value.Trim ();
            if (!value.StartsWith ("0x", StringComparison.InvariantCultureIgnoreCase))
                return value;
            return value.Substring (2);
        }

        int IntFromHex (string hex)
        {
            try
            {
                return Convert.ToInt32 (CleanHex (hex), 16);
            }
            catch (FormatException)
            {
                return -1;
            }
        }
    }
}
