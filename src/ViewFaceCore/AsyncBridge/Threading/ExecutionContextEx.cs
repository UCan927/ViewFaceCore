#if !NET45_OR_GREATER // net40 ����Ͱ汾

#if NET35 || PORTABLE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Threading
{
    internal static class ExecutionContextEx
    {
        public static void Dispose(this ExecutionContext context)
        {
        }
    }
}

#endif

#endif