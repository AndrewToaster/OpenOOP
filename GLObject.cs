using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenOOP
{
    /// <summary>
    /// Base class for all OpenGL Objects
    /// </summary>
    public abstract class GLObject : IDisposable, IEquatable<GLObject>
    {
        /// <summary>
        /// The handle/pointer for the object
        /// </summary>
        public int ObjectHandle { get; protected init; }

        /// <summary>
        /// Constructs a new <see cref="GLObject"/> with it's <see cref="ObjectHandle"/> set to zero
        /// </summary>
        protected GLObject()
        {
            ObjectHandle = 0;
        }

        /// <summary>
        /// Constructs a new <see cref="GLObject"/> with it's <see cref="ObjectHandle"/> set to <paramref name="handle"/>
        /// </summary>
        protected GLObject(int handle)
        {
            ObjectHandle = handle;
        }

        /// <summary>
        /// Implicitly convert <paramref name="obj"/> into it's <see cref="ObjectHandle"/>
        /// </summary>
        /// <param name="obj"></param>
        public static implicit operator int(GLObject obj)
        {
            return obj.ObjectHandle;
        }

        /// <summary>
        /// Creates a new empty <see cref="GLObject"/> <typeparamref name="TObj"/> with it's handle set to <paramref name="handle"/>
        /// </summary>
        /// <typeparam name="TObj"></typeparam>
        /// <param name="handle"></param>
        /// <returns>The new <see cref="GLObject"/> <typeparamref name="TObj"/></returns>
        [Obsolete("For whatever reason you may be using this, please think about what might happen. This creates an GLObject, but only initializes it's handle")]
        public static TObj GetFromHandle<TObj>(int handle) where TObj : GLObject
        {
            Type type = typeof(TObj);
            TObj glObj = (TObj)FormatterServices.GetUninitializedObject(type);
            type.GetProperty(nameof(glObj.ObjectHandle)).SetValue(glObj, handle);

            return glObj;
        }

        /// <summary>
        /// Binds the object as current
        /// </summary>
        public abstract void Bind();

        /// <summary>
        /// Performs application-defined tasks associated with freeing,
        /// releasing, or resetting unmanaged resources.
        /// </summary>
        public abstract void Dispose();

        #region Equality & stuff

        public static bool operator ==(GLObject left, GLObject right)
        {
            return EqualityComparer<GLObject>.Default.Equals(left, right);
        }

        public static bool operator !=(GLObject left, GLObject right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as GLObject);
        }

        public bool Equals(GLObject other)
        {
            return other != null &&
                   ObjectHandle == other.ObjectHandle;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ObjectHandle);
        }

        #endregion Equality & stuff
    }
}
