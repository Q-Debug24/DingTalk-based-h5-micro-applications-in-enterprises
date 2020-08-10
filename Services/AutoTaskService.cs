using DingDingPuls.Controllers;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DingDingPuls.Services
{
    public class AutoTaskService : BackgroundService
    {
        private DingTalkController _talkController;
        private readonly ILogger<AutoTaskService> _logger;

        public AutoTaskService(ILogger<AutoTaskService> logger, DingTalkController talkController)
        {
            _logger = logger;
            _talkController = talkController;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await new TaskFactory().StartNew(() =>
                {
                    try
                    {
                        //每天早上9：00发送工作消息
                        var time = DateTime.Now.ToString("HH:mm:ss");
                        if ("17:09:00" == time)
                        {
                            _logger.LogInformation("发送工作消息");
                            DoWork();
                            _talkController.SendWrokMsg("manager999", "测试消息3");
                        }

                        if ("17:10:00" == time)
                        {
                            _logger.LogInformation("发送工作消息");
                            DoWork();
                            _talkController.SendWrokMsg("manager999", "测试消息2");
                        }
                        if ("17:12:00" == time)
                        {
                            _logger.LogInformation("发送工作消息");
                            DoWork();
                            _talkController.SendWrokMsg("manager999", "测试消息3");
                        }
                    }
                    catch (Exception e)
                    {
                        _logger.LogError("工作消息发送失败" + e.Message);
                    }

                    //定时任务休眠
                });
            }
        }

        private void DoWork()
        {
            _talkController.GetAuthToken();
        }
    }
}