using System;
using System.Runtime.InteropServices;
using OpenTK.Graphics.OpenGL4;

namespace OpenOOP
{
    /// <summary>
    /// Represent a <see cref="GLObject"/> wrapper around OpenGL Buffers
    /// </summary>
    public class GLBuffer : GLObject
    {
        /// <summary>
        /// The <see cref="BufferTarget"/> of this <see cref="GLBuffer"/>
        /// </summary>
        public BufferTarget Target { get; }

        /// <summary>
        /// Creates a new instance of <see cref="GLBuffer"/>
        /// </summary>
        /// <param name="type">The type of the <see cref="GLBuffer"/></param>
        public GLBuffer(BufferTarget type)
        {
            Target = type;
            ObjectHandle = GL.GenBuffer();
        }

        public override void Bind()
        {
            GL.BindBuffer(Target, ObjectHandle);
        }

        /// <summary>
        /// Buffers data into this <see cref="GLBuffer"/>
        /// </summary>
        /// <typeparam name="T">The generic structure to buffer</typeparam>
        /// <param name="data">The data to buffer</param>
        /// <param name="hint">The usage hint of the memory</param>
        public void BufferData<T>(T[] data, BufferUsageHint hint) where T : struct
        {
            Bind();
            GL.BufferData(Target, data.Length * Marshal.SizeOf<T>(), data, hint);
        }

        /// <summary>
        /// Buffers <see cref="float"/> data into this <see cref="GLBuffer"/>
        /// </summary>
        /// <param name="data">The data to buffer</param>
        /// <param name="hint">The usage hint of the memory</param>
        public void BufferFloat(float[] data, BufferUsageHint hint)
        {
            Bind();

            // This fucking line of code cost me so much time to resolve
            // i was missing a teeny-tiny piece of code.
            // * sizeof(float)
            // pain (:
            GL.BufferData(Target, data.Length * sizeof(float), data, hint);
        }

        /// <summary>
        /// Buffers <see cref="uint"/> data into this <see cref="GLBuffer"/>
        /// </summary>
        /// <param name="data">The data to buffer</param>
        /// <param name="hint">The usage hint of the memory</param>
        public void BufferUInt(uint[] data, BufferUsageHint hint)
        {
            Bind();
            GL.BufferData(Target, data.Length * sizeof(uint), data, hint);
        }

        /// <summary>
        /// Buffers <see cref="int"/> data into this <see cref="GLBuffer"/>
        /// </summary>
        /// <param name="data">The data to buffer</param>
        /// <param name="hint">The usage hint of the memory</param>
        public void BufferInt(int[] data, BufferUsageHint hint)
        {
            Bind();
            GL.BufferData(Target, data.Length * sizeof(int), data, hint);
        }

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
            GL.BindBuffer(Target, 0);
            GL.DeleteBuffer(ObjectHandle);
        }
    }
}
