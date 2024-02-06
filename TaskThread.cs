
namespace Tec
{
    internal class TaskThread
    {
        public void Run()
        {
            asyncFunc(); //same time run
            asyncFunc2(); //same time run
        }

        private async void asyncFunc()
        {
            var v = await getData(); //wait
            Console.WriteLine(v); //after 1000
        }
        private async void asyncFunc2()
        {
            var v = await getData(); //wait
            var v2 = await getData(); //wait
            Console.WriteLine(v + v2); //after 2000
        }

        private async Task<int> getData()
        {
            await Task.Delay(1000); //1000 time wait
            return 1;
        }
    }
}
