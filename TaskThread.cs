
namespace Tec
{
    internal class TaskThread
    {
        public void Run()
        {
            AsyncFunc(); //same time run
            AsyncFunc2(); //same time run
        }

        private async void AsyncFunc()
        {
            var v = await GetData(); //wait
            Console.WriteLine(v); //after 1000
        }
        private async void AsyncFunc2()
        {
            var v = await GetData(); //wait
            var v2 = await GetData(); //wait
            Console.WriteLine(v + v2); //after 2000
        }

        private async Task<int> GetData()
        {
            await Task.Delay(1000); //1000 time wait
            return 1;
        }
    }
}
