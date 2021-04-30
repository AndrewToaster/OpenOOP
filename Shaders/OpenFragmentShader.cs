using OpenTK.Graphics.OpenGL4;

namespace OpenOOP.Shaders
{
    /// <summary>
    /// Represents a <see cref="GLShader"/> wrapper around the <see cref="ShaderType.FragmentShader"/>
    /// </summary>
    public sealed class OpenFragmentShader : GLShader
    {
        /// <summary>
        /// Constructs a new instance of <see cref="OpenFragmentShader"/>
        /// </summary>
        /// <param name="shaderSourceCode">The fragment shader source code</param>
        public OpenFragmentShader(string shaderSourceCode) : base(shaderSourceCode, ShaderType.FragmentShader)
        {
        }
    }
}
