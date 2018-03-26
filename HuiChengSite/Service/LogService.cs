using Autofac.Integration.Mvc;
using HuiChengSite.Common;
using HuiChengSite.Models;
using HuiChengSite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HuiChengSite.Service
{
    public class LogService
    {
        public static LogService Instance
        {
            get
            {
                var service = AutofacDependencyResolver.Current.GetService(typeof(LogService)) as LogService;
                return service;
            }
        }

        private LogRepository _LogRepository;

        public LogService(LogRepository LogRepository)
        {
            _LogRepository = LogRepository;
        }

        public void AddAsync(Level level, Exception ex)
        {
            this.AddAsync(level, $"{ex.Message} {ex.StackTrace}");
        }

        public void AddAsync(Level level, string msg)
        {
            Task.Run(() =>
            {
                int configLevel = Convert.ToInt32(Configer.Get("logLevel"));
                if ((int)level < configLevel)
                    return;

                Log model = new Log();
                model.Level = level.ToString();
                model.Logger = "日志博客";
                model.Message = msg;
                Add(model);
            });
        }

        public int Add(Log model)
        {
            model.Date = DateTime.Now;

            var id = _LogRepository.Add(model);
            return id;
        }

        public LogListModelResult GetPaged(LogListQuery listModel)
        {
            return _LogRepository.GetPaged(listModel);
        }
    }
}