using System;
using OpenTK.Graphics.OpenGL4;

namespace OpenOOP.Buffers
{
    /// <summary>
    /// Wrapper around the <see cref="GLBuffer"/> using the <see cref="BufferTarget.ArrayBuffer"/> target
    /// </summary>
    public sealed class OpenVBO : GLBuffer
    {
        /// <summary>
        /// Constructs a new instance of <see cref="OpenVBO"/>
        /// </summary>
        public OpenVBO() : base(BufferTarget.ArrayBuffer)
        {
        }
    }
}
