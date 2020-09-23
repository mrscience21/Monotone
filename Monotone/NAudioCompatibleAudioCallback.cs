using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech.Audio;
using NAudio.Wave;

namespace Monotone
{
    /// <summary>
    /// Implementation of <see cref="PullAudioInputStreamCallback"/> that is compatible with <see cref="NAudio"/>
    /// </summary>
    public class NAudioCompatibleAudioCallback : PullAudioInputStreamCallback
    {
        BufferedWaveProvider bufferedWaveProvider;

        /// <summary>
        /// Instantiate an instance of <see cref="NAudioCompatibileAudioCallback"/>
        /// </summary>
        /// <param name="bufferedWaveProvider">A Reference to an instance of <see cref="BufferedWaveProvider"/> storing</param>
        public NAudioCompatibleAudioCallback(ref BufferedWaveProvider bufferedWaveProvider)
        {
            this.bufferedWaveProvider = bufferedWaveProvider;
        }

        /// <summary>
        /// Stores retrieved audio data into the specified dataBuffer
        /// </summary>
        /// <param name="dataBuffer">Byte Array to store recieved data in</param>
        /// <param name="size">Length of dataBuffer holding data</param>
        /// <returns></returns>
        public override int Read(byte[] dataBuffer, uint size)
        {
            return bufferedWaveProvider.Read(dataBuffer, 0, dataBuffer.Length);
        }
    }
}
