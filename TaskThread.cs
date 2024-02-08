
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

        private Action _action;

        public async void Run2()
        {
            int value = await f(); //wait setResult TaskCompletionSource
            //Console.WriteLine(value); print 1
        }
        private Task<int> f()
        {
            var tcs = new TaskCompletionSource<int>();

            _action += () => { tcs.SetResult(1); };
            f2(); //delay call callback func
            return tcs.Task;
        }
        private async void f2()
        {
            await Task.Delay(1000);
            _action();
        }

        public async void Run3()
        {
            var t1 = Task.Delay(1000);
            var t2 = f3();

            await Task.WhenAny(t1, t2);
            //t1, t2 any complete, do

            await Task.WhenAll(t1, t2);
            //t1, t2 all complete, do
        }
        private async Task<int> f3()
        {
            await Task.Delay(1000);
            return 1;
        }

    }
}
