
namespace Tec
{
    internal class StreamCommunicate
    {
        private Stream _stream;

        public StreamCommunicate(Stream s)
        {
            _stream = s;
            _stream.ReadTimeout = 1000;
            _stream.WriteTimeout = 1000;
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


        public static ushort CRC16(byte[] data)
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

        public async Task WriteAsync(byte[] data)
        {
            try
            {
                //await _stream.WriteAsync(data); // timeout no work //infinity wait
                await Task.Run(() =>
                {
                    _stream.Write(data); //+time catch
                });
            }
            catch (Exception ex)
            {
                throw new Exception("write error: ", ex);
            }
        }

        public async Task<byte[]> ReadAsync()
        {
            const int BUF_SIZE = 512;
            var buffer = new byte[BUF_SIZE];
            int len = 0;
            try
            {
                //len = await _stream.ReadAsync(buffer); //timeout no work
                await Task.Run(() =>
                {
                    len = _stream.Read(buffer);
                });
            }
            catch (Exception e)
            {
                throw new Exception("read error: ", e);
            }

            var data = new byte[len];
            Array.Copy(buffer, data, len);
            return data;
        }
    }
}
