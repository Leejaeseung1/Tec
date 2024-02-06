
namespace Tec
{
    internal class TaskThread
    {
        public void Run()
        {
            asyncFunc();
            asyncFunc2();
        }

        private async void asyncFunc()
        {
            var v = await getData(); //wait, run call thread next Run()
            Console.WriteLine(v); //run after 1000
        }
        private async void asyncFunc2()
        {
            var v = await getData(); //wait, run call thread next Run()
            var v2 = await getData(); //wait, same
            Console.WriteLine(v + v2); //after 2000
        }

        private async Task<int> getData()
        {
            await Task.Delay(1000); //1000 time wait
            return 1;
        }
    }
}
