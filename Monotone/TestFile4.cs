using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Monotone
{
    class TestFile4
    {
        private WaveFileWriter fileWriter;

        public void testFunc()
        {
            Console.WriteLine(WaveInEvent.GetCapabilities(0).Channels);

        }
    }
}
