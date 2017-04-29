using JobScheduler.Win.Service.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace JobScheduler.Win.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            //1、配置一个最简单服务
            HostFactory.Run(x =>
            {
                //2、采用 HostFactory.Run开启服务宿主
                x.Service<JobSchedulerServer>(s =>
                {
                    //3、配置一个完全定制的服务,对Topshelf没有依赖关系。常用的方式。
                    s.ConstructUsing(name => new JobSchedulerServer());
                    //4、服务开始的事件
                    s.WhenStarted(tc => tc.Start());
                    //5、服务停止以后事件
                    s.WhenStopped(tc => tc.Stop());
                });
                // 6、服务使用NETWORK_SERVICE内置帐户运行。身份标识，有好几种方式，如：x.RunAs("username", "password");  x.RunAsPrompt(); x.RunAsNetworkService(); 等
                x.RunAsLocalSystem();

                //7、服务描述
                x.SetDescription("JobScheduler调度服务");
                //8、服务显示名称
                x.SetDisplayName("JobScheduler");
                //9、服务名称
                x.SetServiceName("JobScheduler");
            }); //10、服务启动
        }
    }
}
