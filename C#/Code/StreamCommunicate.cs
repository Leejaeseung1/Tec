
using System.Text;

namespace Tec
{
    internal class StreamCommunicate
    {
        private const int TIMEOUT = 1000;

        private Stream _stream;

        public StreamCommunicate(Stream s)
        {
            _stream = s;
        }

        public void Play() //Ex(), do: same time play
        {
            ex();

            // do
        }

        private async void ex() //async func
        {
            await WriteAsync(new byte[] { 1, 2 }); //wait write

            // do after write

            var data = await ReadAsync(); //wait read

            // do after read
        }

        public static ushort CRC16(byte[] data) //make crc16
        {
            var size = data.Length;

            int cr = 0xFFFF;
            for (int i = 0; i < size; i++)
            {
                cr = cr ^ data[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((cr & 0x0001) == 0x0001)
                    {
                        cr >>= 1;
                        cr ^= 0xA001;
                    }
                    else
                    {
                        cr >>= 1;
                    }
                }
            }
            return (ushort)cr;
        }

        public Task WriteAsync(string data)
        {
            return WriteAsync(Encoding.UTF8.GetBytes(data));
        }

        public async Task WriteAsync(byte[] data)
        {
            try
            {
                //await Task.Run(() =>
                //{
                //    _stream.ReadTimeout = TIMEOUT;
                //    _stream.WriteTimeout = TIMEOUT;
                //    _stream.Write(data); //timeout catch, but make task.run()
                //});

                //await _stream.WriteAsync(data); // timeout no work //infinity wait

                await timeout(_stream.WriteAsync(data).AsTask(), TIMEOUT);
            }
            catch (Exception ex)
            {
                throw new Exception("write error: ", ex);
            }
        }

        public async Task<T> ReadAsync<T>()
        {
            var data = await readAsync();
            object o = null;

            if (typeof(T) == typeof(byte[]))
            {
                o = data;
            }
            if (typeof(T) == typeof(string))
            {
                o = Encoding.UTF8.GetString(data);
            }

            if (o is null)
            {
                throw new Exception("receive fail");
            }

            return (T)o;
        }

        private async Task<byte[]> readAsync()
        {
            const int BUF_SIZE = 512;
            var buffer = new byte[BUF_SIZE];
            int len = 0;
            try
            {
                len = await timeout(_stream.ReadAsync(buffer, 0, BUF_SIZE), TIMEOUT);
            }
            catch (Exception e)
            {
                throw new Exception("read error: ", e);
            }

            var data = new byte[len];
            Array.Copy(buffer, data, len);
            return data;
        }

        private async Task timeout(Task t, int millisecs) //return void
        {
            var v = await Task.WhenAny(t, Task.Delay(millisecs));

            if (v != t)
            {
                throw new TimeoutException("timeout");
            }
        }

        private async Task<T> timeout<T>(Task<T> t, int millisecs) //return <T>
        {
            var v = await Task.WhenAny(t, Task.Delay(millisecs));

            if (v != t)
            {
                throw new TimeoutException("timeout");
            }

            return t.Result;
        }
    }
}
