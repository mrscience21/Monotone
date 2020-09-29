using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monotone
{
    /// <summary>
    /// Object representng a single line of an Entry
    /// </summary>
    [Serializable]
    public class EntryLine
    {
        /// <summary>
        /// Single Line Text
        /// </summary>
        public string Text { set; get; }

        /// <summary>
        /// Single Line Time Stamp
        /// </summary>
        public TimeSpan TimeStamp { set; get; }

        /// <summary>
        /// Instantiates an <see cref="EntryLine"/> object
        /// </summary>
        /// <param name="Text">Single Line Text</param>
        /// <param name="TimeStamp">Single Line Time Stamp</param>
        public EntryLine(string Text, TimeSpan TimeStamp)
        {
            this.Text = Text;
            this.TimeStamp = TimeStamp;
        }
    }
}
