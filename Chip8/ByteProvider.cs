using Be.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8
{
    class ByteProvider
        : IByteProvider
    {
        public event EventHandler Changed;
        public event EventHandler LengthChanged;
        public event EventHandler<long> BytesModified;

        byte[] _data;

        public long Length { get { return _data.Length; } }

        public ByteProvider (byte[] data)
        {
            _data = data;
        }

        public bool HasChanges () { return false; }

        public bool SupportsDeleteBytes () { return false; }
        public bool SupportsInsertBytes () { return false; }
        public bool SupportsWriteByte () { return true; }

        public void ApplyChanges () { }
        public void DeleteBytes (long index, long length) { }
        public void InsertBytes (long index, byte[] bs) { }
        public byte ReadByte (long index) { return _data[index]; }
        
        public void WriteByte (long index, byte value)
        {
            _data[index] = value;
            if (BytesModified != null)
                BytesModified.Invoke (this, index);
        }

        public void Refresh ()
        {
            if (Changed != null)
                Changed.Invoke (this, EventArgs.Empty);
        }
    }
}
