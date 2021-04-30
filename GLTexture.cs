using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL4;

namespace OpenOOP.Objects
{
    /// <summary>
    /// Represents a <see cref="GLObject"/> wrapper around OpenGL Textures
    /// </summary>
    public class GLTexture : GLObject, IEquatable<GLTexture>, IComparable<GLTexture>, IComparable
    {
        /// <summary>
        /// Creates a new instance of <see cref="GLTexture"/>
        /// </summary>
        public GLTexture()
        {
            ObjectHandle = GL.GenTexture();
        }

        /// <summary>
        /// Loads a <see cref="GLTexture"/> from a file
        /// </summary>
        /// <param name="file">The file to read the image from</param>
        /// <param name="parameters">Optional delegate for modifying the texture</param>
        /// <returns>The loaded <see cref="GLTexture"/></returns>
        public static GLTexture LoadFromFile(string file, Action<GLTexture, TextureTarget> parameters = null)
        {
            GLTexture tex = new();
            tex.Bind(TextureUnit.Texture0);

            using var image = new Bitmap(file);
            var data = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D,
                0,
                PixelInternalFormat.Rgba,
                image.Width,
                image.Height,
                0,
                OpenTK.Graphics.OpenGL4.PixelFormat.Bgra,
                PixelType.UnsignedByte,
                data.Scan0);

            if (parameters != null)
            {
                parameters.Invoke(tex, TextureTarget.Texture2D);
            }
            else
            {
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
                GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
            }

            return tex;
        }

        /// <summary>
        /// Binds the <see cref="GLTexture"/> as current in the <paramref name="unit"/> slot
        /// </summary>
        /// <param name="unit">The unit/slot to bind the texture in</param>
        public void Bind(TextureUnit unit)
        {
            GL.ActiveTexture(unit);
            GL.BindTexture(TextureTarget.Texture2D, ObjectHandle);
        }

        /// <summary>
        /// Binds the <see cref="GLTexture"/> as current in the <see cref="TextureUnit.Texture0"/> slot
        /// </summary>
        public override void Bind()
        {
            Bind(TextureUnit.Texture0);
        }

        public override void Dispose()
        {
            GL.DeleteTexture(ObjectHandle);
            GC.SuppressFinalize(this);
        }

        #region Equality & stuff

        public static bool operator ==(GLTexture left, GLTexture right)
        {
            return EqualityComparer<GLTexture>.Default.Equals(left, right);
        }

        public static bool operator !=(GLTexture left, GLTexture right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as GLTexture);
        }

        public bool Equals(GLTexture other)
        {
            return other != null && ObjectHandle == other.ObjectHandle;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return -1;
            }

            if (obj is GLTexture x)
            {
                return CompareTo(x);
            }

            throw new ArgumentException("", nameof(obj));
        }

        public int CompareTo(GLTexture other)
        {
            return other is null ? -1 : ObjectHandle.CompareTo(other.ObjectHandle);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ObjectHandle);
        }

        #endregion Equality & stuff
    }
}
