#if !NET45_OR_GREATER // net40 ����Ͱ汾

namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// Represents an asynchronous method builder.
    /// </summary>
    internal interface IAsyncMethodBuilder
    {
        void PreBoxInitialization();
    }
}

#endif