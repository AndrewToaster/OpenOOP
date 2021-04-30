using System;
using OpenTK.Graphics.OpenGL4;

namespace OpenOOP.Objects.Shaders
{
    /// <summary>
    /// Represents a <see cref="GLShader"/> wrapper around the <see cref="ShaderType.VertexShader"/>
    /// </summary>
    public sealed class OpenVertexShader : GLShader
    {
        /// <summary>
        /// Constructs a new instance of <see cref="OpenVertexShader"/>
        /// </summary>
        /// <param name="shaderSourceCode">The vertex shader source code</param>
        public OpenVertexShader(string shaderSourceCode) : base(shaderSourceCode, ShaderType.VertexShader)
        {
        }
    }
}
