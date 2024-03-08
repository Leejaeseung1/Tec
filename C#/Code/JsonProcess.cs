using System.Text.Json.Serialization;
using System.Text.Json;

namespace C_.Code
{
    internal class JsonProcess
    {
        public void MakeJson<T>(string path, T data)
        {
            if (!path.Contains(".json"))
            {
                throw new Exception("file name error");
            }

            var options = new JsonSerializerOptions();
            options.WriteIndented = true; //pretty indented line
            options.Converters.Add(new JsonStringEnumConverter()); //enum -> string

            string jsonString;
            try
            {
                jsonString = JsonSerializer.Serialize(data, options);
            }
            catch (Exception ex)
            {
                throw new Exception("Serialize error", ex);
            }

            File.WriteAllText(path, jsonString);
        }

        public T[] GetDatasFromJson<T>(string jsonPath)
        {
            var str = File.ReadAllText(jsonPath);

            var options = new JsonSerializerOptions();
            options.Converters.Add(new JsonStringEnumConverter()); //MakeJson same converter

            List<T> deSerial;
            try
            {
                deSerial = JsonSerializer.Deserialize<List<T>>(str, options);
            }
            catch (Exception e)
            {
                throw new Exception("deserialize error", e);
            }

            if (deSerial == null)
                throw new Exception("return list is null");

            return deSerial.ToArray();
        }

        public enum TestEnum
        {
            None, One, Two, Three
        }

        public class Test
        {
            public int DataInt;
            public string DataString;
            public TestEnum DataEnum;
        }

        public void Make()
        {
            List<Test> dataList = new List<Test>()
            {
                new Test(){DataInt =1, DataString = "n1", DataEnum = TestEnum.One },
                new Test(){DataInt =2, DataString = "n2", DataEnum = TestEnum.Two },
                new Test(){DataInt =3, DataString = "n3", DataEnum = TestEnum.Three },
            };

            MakeJson("data.json", dataList);
        }

        public void Read()
        {
            Test[] dataArray = GetDatasFromJson<Test>("data.json");
        }
    }
}
