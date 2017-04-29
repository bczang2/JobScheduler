jobScheduler for .net
========
基于quartz.net框架: 使用mysql持久化存储job信息、使用topshelf框架集成window服务<br/>
JobScheduler.Core： job处理核心相关类
<br/>
JobScheduler.DataAccess:  使用dapper获取job相关信息
<br/>
JobScheduler.Web.Console: job信息展示、调度及简单操作界面
<br/>
JobScheuler.Win.Server:   采用topshelf集成window服务调度job
