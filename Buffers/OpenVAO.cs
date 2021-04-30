using System;
using OpenTK.Graphics.OpenGL4;

namespace OpenOOP.Objects.Buffers
{
    /// <summary>
    /// Represents a <see cref="GLObject"/> wrapper around OpenGL VertexArrays
    /// </summary>
    public sealed class OpenVAO : GLObject
    {
        /// <summary>
        /// Constructs a new instance of <see cref="OpenVAO"/>
        /// </summary>
        public OpenVAO()
        {
            ObjectHandle = GL.GenVertexArray();
        }

        public override void Bind()
        {
            GL.BindVertexArray(ObjectHandle);
        }

        public override void Dispose()
        {
            GL.BindVertexArray(0);
            GL.DeleteVertexArray(ObjectHandle);
        }
    }
}
