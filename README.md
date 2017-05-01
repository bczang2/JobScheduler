jobScheduler for .net
========
基于quartz.net框架，只提供job调度服务，具体job业务逻辑需由调用方实现，提供对应url即可，如restful api或者soa；使用mysql持久化存储job信息、使用topshelf框架集成window服务；调用方通过web管理界面可以新增job，配置job参数。<br/><br/>
JobScheduler.Core： job处理核心相关类
<br/><br/>
JobScheduler.DataAccess:  使用dapper获取job相关信息
<br/><br/>
JobScheduler.Web.Console: job信息展示、调度及简单操作界面
<br/><br/>
JobScheuler.Win.Server:   采用topshelf集成window服务调度job
