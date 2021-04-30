using System;

namespace OpenOOP.Objects.Buffers
{
    /// <summary>
    /// Utility class used for OpenGL Objects using factories and actions to handle it's creation and destruction
    /// </summary>
    public sealed class OpenObject : GLObject
    {
        private readonly Action<OpenObject> _bind;
        private readonly Action<OpenObject> _dispose;

        /// <summary>
        /// Creates a new instance <see cref="OpenObject"/>
        /// </summary>
        /// <param name="factory">The factory that creates the Object</param>
        /// <param name="dispose">The action that destroys the Object</param>
        public OpenObject(Func<int> factory, Action<OpenObject> bind, Action<OpenObject> dispose) : base(factory.Invoke())
        {
            _bind = bind;
            _dispose = dispose;
        }

        public override void Bind()
        {
            _bind.Invoke(this);
        }

        public override void Dispose()
        {
            _dispose.Invoke(this);
        }
    }
}
