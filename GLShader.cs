using System;
using OpenTK.Graphics.OpenGL4;

namespace OpenOOP.Objects
{
    /// <summary>
    /// Represents a <see cref="GLObject"/> wrapper around OpenGL Shaders
    /// </summary>
    public class GLShader : GLObject
    {
        /// <summary>
        /// The <see cref="ShaderType"/> of this <see cref="GLShader"/>
        /// </summary>
        public ShaderType Type { get; }

        /// <summary>
        /// Constructs a new instance of <see cref=""/>
        /// </summary>
        /// <param name="shaderSourceCode"></param>
        /// <param name="type"></param>
        public GLShader(string shaderSourceCode, ShaderType type)
        {
            ObjectHandle = GL.CreateShader(type);
            GL.ShaderSource(ObjectHandle, shaderSourceCode);
            GL.CompileShader(ObjectHandle);

            GL.GetShader(ObjectHandle, ShaderParameter.CompileStatus, out int success);
            if (success != 1)
            {
                Console.WriteLine($"ERROR IN SHADER COMPILATION: {GL.GetShaderInfoLog(ObjectHandle)}");
            }
        }

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
            GL.DeleteShader(ObjectHandle);
        }

        /// <summary>
        /// This method has no functionality, shaders use GL.AttachShader(int program, int shader)
        /// </summary>
        [Obsolete("This method has no functionality, shaders use GL.AttachShader(int program, int shader)", true)]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
        public override void Bind()
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member
        {
        }
    }
}
