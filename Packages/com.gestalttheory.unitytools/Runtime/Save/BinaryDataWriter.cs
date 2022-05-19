using System.IO;
using UnityEngine;

namespace UnityTools.Runtime.Save
{
    public class BinaryDataWriter
    {
        private readonly BinaryWriter _writer;

        public BinaryDataWriter(BinaryWriter writer)
        {
            _writer = writer;
        }

        public void Write(string value)
        {
            _writer.Write(value);
        }

        public void Write(byte value)
        {
            _writer.Write(value);
        }

        public void Write(byte[] value)
        {
            _writer.Write(value);
        }

        public void Write(short value)
        {
            _writer.Write(value);
        }

        public void Write(int value)
        {
            _writer.Write(value);
        }

        public void Write(long value)
        {
            _writer.Write(value);
        }

        public void Write(float value)
        {
            _writer.Write(value);
        }

        public void Write(double value)
        {
            _writer.Write(value);
        }

        public void Write(bool value)
        {
            _writer.Write(value);
        }

        public void Write(Vector3 value)
        {
            _writer.Write(value.x);
            _writer.Write(value.y);
            _writer.Write(value.z);
        }
    }
}