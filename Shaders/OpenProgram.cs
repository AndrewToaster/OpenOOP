using System;
using OpenTK.Graphics.OpenGL4;

namespace OpenOOP.Shaders
{
    /// <summary>
    /// Represents a <see cref="GLObject"/> wrapper around OpenGL Rendering Pipeline
    /// </summary>
    public sealed class OpenProgram : GLObject
    {
        /// <summary>
        /// Constructs a new instance of <see cref="OpenProgram"/>
        /// </summary>
        /// <param name="vertex">The vertex shader</param>
        /// <param name="fragment">The fragment shader</param>
        public OpenProgram(OpenVertexShader vertex, OpenFragmentShader fragment)
        {
            ObjectHandle = GL.CreateProgram();

            GL.AttachShader(ObjectHandle, vertex);
            GL.AttachShader(ObjectHandle, fragment);
            GL.LinkProgram(ObjectHandle);

            GL.GetProgram(ObjectHandle, GetProgramParameterName.LinkStatus, out int success);
            if (success != 1)
            {
                Console.WriteLine($"ERROR LINKING PROGRAM: {GL.GetProgramInfoLog(ObjectHandle)}");
            }
            else
            {
                vertex.Dispose();
                fragment.Dispose();
            }
        }

        /// <summary>
        /// Binds the object as current
        /// </summary>
        public override void Bind()
        {
            GL.UseProgram(ObjectHandle);
        }

        public override void Dispose()
        {
            GL.UseProgram(0);
            GL.DeleteProgram(ObjectHandle);
        }
    }
}
