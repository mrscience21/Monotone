using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monotone
{
    /// <summary>
    /// Event Arguments for passing File Paths between objects in the Monotone Application
    /// </summary>
    public class MonotoneFileEventArgs : EventArgs
    {
        /// <summary>
        /// Full path including file name and extension, if applicable
        /// </summary>
        public string FilePath { set; get; } = string.Empty;

        /// <summary>
        /// Instantiates an instance of <see cref="MonotoneFileEventArgs"/>
        /// </summary>
        /// <param name="FilePath">Full path including file name and extension, if applicable</param>
        public MonotoneFileEventArgs(string FilePath)
        {
            this.FilePath = FilePath;
        }
    }
}
