using OpenTK.Graphics.OpenGL4;

namespace OpenOOP.Buffers
{
    /// <summary>
    /// Wrapper around the <see cref="GLBuffer"/> using the <see cref="BufferTarget.ElementArrayBuffer"/> target
    /// </summary>
    public sealed class OpenEAB : GLBuffer
    {
        /// <summary>
        /// Constructs a new instance of <see cref="OpenEAB"/>
        /// </summary>
        public OpenEAB() : base(BufferTarget.ElementArrayBuffer)
        {
        }
    }
}
